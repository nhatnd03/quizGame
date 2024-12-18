using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using Newtonsoft.Json;

namespace quizGame
{
    public partial class StartForm : Form
    {
        private Form1 mainForm;
        private string dbPath = "quiziz.db";
        public bool isChecked { get; set; } = false;
        public StartForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Ngăn resize
            this.MaximizeBox = false; // Ẩn nút phóng to
            this.MinimizeBox = true; // Hiển thị nút thu nhỏ (tuỳ chọn)
            CreateDatabase();
            LoadQuestions();
            PopulateLevelComboBox();
            dgvQuestions.SelectionChanged += DgvQuestions_SelectionChanged; // Sử dụng sự kiện SelectionChanged
        }

        private void DgvQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                QuestionAndAnswers selectedQuestion = (QuestionAndAnswers)dgvQuestions.SelectedRows[0].DataBoundItem;
                txtQues.Text = selectedQuestion.Questions;
                txtAnsw.Text = selectedQuestion.AnswersString;
                txtCorrectAns.Text = selectedQuestion.CorrectAnswer.ToString();
            }
            else
            {
                txtQues.Clear();
                txtAnsw.Clear();
                txtCorrectAns.Clear();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int selectedLevel = comboBox1.SelectedIndex + 1;

                if (mainForm == null)
                {
                    mainForm = new Form1(this); // Truyền StartForm vào Form1
                    mainForm.Owner = this; // Thiết lập Owner để hỗ trợ quay lại
                }

                List<QuestionAndAnswers> questionsForLevel = GetQuestionsByLevel(selectedLevel);
                if (questionsForLevel.Count == 0)
                {
                    MessageBox.Show($"Không có câu hỏi cho level {selectedLevel}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra xem checkbox `checkSort` có được chọn hay không
                if (isChecked)
                {
                    // Sắp xếp ngẫu nhiên danh sách câu hỏi
                    Random random = new Random();
                    questionsForLevel = questionsForLevel.OrderBy(q => random.Next()).ToList();
                }

                mainForm.UpdateQuestions(questionsForLevel, selectedLevel);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn level!");
            }
        }


        private List<QuestionAndAnswers> GetQuestionsByLevel(int level)
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            int questionsPerLevel = 40; // Số câu hỏi mỗi level
            int offset = (level - 1) * questionsPerLevel;

            List<QuestionAndAnswers> questions = new List<QuestionAndAnswers>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT * FROM questionanswer LIMIT @Limit OFFSET @Offset";
                    command.Parameters.AddWithValue("@Limit", questionsPerLevel);
                    command.Parameters.AddWithValue("@Offset", offset);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QuestionAndAnswers question = new QuestionAndAnswers
                            {
                                Id = reader.GetInt32(0),
                                Questions = reader.GetString(1),
                                Answers = JsonConvert.DeserializeObject<List<string>>(reader.GetString(2)),
                                CorrectAnswer = reader.GetInt32(3)
                            };
                            questions.Add(question);
                        }
                    }
                }
            }

            return questions;
        }



        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportQuestionsFromDocx(openFileDialog.FileName);
                    MessageBox.Show("Câu hỏi đã được nhập thành công!");
                    LoadQuestions(); // Reload data after import
                    PopulateLevelComboBox(); // Update level combobox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nhập câu hỏi: " + ex.Message);
                }
            }
        }
        private void CreateDatabase()
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS questionanswer (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Question TEXT NOT NULL,
                                                Answer BLOB NOT NULL,
                                                CorrectAnswer INTEGER NOT NULL
                                            )";
                    command.ExecuteNonQuery();
                }
            }
        }
        private void ImportQuestionsFromDocx(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
            {
                string connectionString = $"Data Source={dbPath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.Transaction = transaction;
                            command.CommandText = "INSERT INTO questionanswer (Question, Answer, CorrectAnswer) VALUES (@Question, @Answer, @CorrectAnswer)";
                            command.Parameters.AddWithValue("@Question", "");
                            command.Parameters.AddWithValue("@Answer", "");
                            command.Parameters.AddWithValue("@CorrectAnswer", 0);

                            string question = "";
                            List<string> answers = new List<string>();
                            int correctAnswer = 0;

                            foreach (var paragraph in doc.MainDocumentPart.Document.Body.Descendants<Paragraph>())
                            {
                                string text = paragraph.InnerText.Trim();
                                if (string.IsNullOrEmpty(text)) continue;

                                if (text.StartsWith("A.") || text.StartsWith("B.") || text.StartsWith("C.") || text.StartsWith("D."))
                                {
                                    answers.Add(text.Substring(2).Trim());
                                }
                                else if (int.TryParse(text, out correctAnswer))
                                {
                                    if (correctAnswer >= 0 && correctAnswer < answers.Count)
                                    {
                                        string jsonAnswers = JsonConvert.SerializeObject(answers);
                                        command.Parameters["@Question"].Value = question;
                                        command.Parameters["@Answer"].Value = jsonAnswers;
                                        command.Parameters["@CorrectAnswer"].Value = correctAnswer;
                                        command.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        throw new Exception("Đáp án đúng không hợp lệ!");
                                    }
                                    question = "";
                                    answers.Clear();
                                }
                                else
                                {
                                    question = text;
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
        }
        private void LoadQuestions()
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT * FROM questionanswer";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        List<QuestionAndAnswers> questions = new List<QuestionAndAnswers>();
                        while (reader.Read())
                        {
                            QuestionAndAnswers question = new QuestionAndAnswers();
                            question.Id = reader.GetInt32(0);
                            question.Questions = reader.GetString(1);
                            string jsonAnswers = reader.GetString(2);
                            question.Answers = JsonConvert.DeserializeObject<List<string>>(jsonAnswers);
                            question.AnswersString = QuestionAndAnswers.JsonStringToString(jsonAnswers);
                            question.CorrectAnswer = reader.GetInt32(3);
                            questions.Add(question);
                        }

                        dgvQuestions.AutoGenerateColumns = false;
                        dgvQuestions.Columns.Clear(); // Clear existing columns

                        DataGridViewTextBoxColumn questionColumn = new DataGridViewTextBoxColumn();
                        questionColumn.DataPropertyName = "Questions";
                        questionColumn.HeaderText = "Question";
                        dgvQuestions.Columns.Add(questionColumn);

                        DataGridViewTextBoxColumn answerColumn = new DataGridViewTextBoxColumn();
                        answerColumn.DataPropertyName = "AnswersString";
                        answerColumn.HeaderText = "Answers";
                        dgvQuestions.Columns.Add(answerColumn);

                        DataGridViewTextBoxColumn correctAnswerColumn = new DataGridViewTextBoxColumn();
                        correctAnswerColumn.DataPropertyName = "CorrectAnswer";
                        correctAnswerColumn.HeaderText = "Correct Answer";
                        dgvQuestions.Columns.Add(correctAnswerColumn);

                        dgvQuestions.DataSource = questions;
                        dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvQuestions.AllowUserToAddRows = false;
                    }
                }
            }
        }

        private void PopulateLevelComboBox()
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM questionanswer", connection))
                {
                    int totalQuestions = Convert.ToInt32(command.ExecuteScalar());
                    int numLevels = (int)Math.Ceiling((double)totalQuestions / 40);

                    comboBox1.Items.Clear();
                    for (int i = 1; i <= numLevels; i++)
                    {
                        comboBox1.Items.Add($"Level {i}");
                    }
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                }
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LoadQuestions(); // Load questions when the form loads
            PopulateLevelComboBox(); // Update level combobox
            this.label1.BackColor = this.BackColor;
        }
        #region Sửa 1 câu hỏi
        private void btnSua_Click(object sender, EventArgs e)
        {
            //Implementation for updating question
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                QuestionAndAnswers selectedQuestion = (QuestionAndAnswers)dgvQuestions.SelectedRows[0].DataBoundItem;
                UpdateQuestion(selectedQuestion);
                MessageBox.Show("Sửa thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuestions(); // Load lại datagridview sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần sửa!");
            }
        }

        private void UpdateQuestion(QuestionAndAnswers question)
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE questionanswer SET Question = @Question, Answer = @Answer, CorrectAnswer = @CorrectAnswer WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Question", txtQues.Text);
                    command.Parameters.AddWithValue("@Answer", JsonConvert.SerializeObject(question.Answers));
                    command.Parameters.AddWithValue("@CorrectAnswer", int.Parse(txtCorrectAns.Text));
                    command.Parameters.AddWithValue("@Id", question.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Xóa tất cả câu hỏi
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả câu hỏi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ClearAllQuestions();
                LoadQuestions(); // Load lại datagridview sau khi xóa
                PopulateLevelComboBox(); // Cập nhật lại combobox level
            }
        }

        private void ClearAllQuestions()
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM questionanswer", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
        #region Xóa 1 câu hỏi
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                QuestionAndAnswers selectedQuestion = (QuestionAndAnswers)dgvQuestions.SelectedRows[0].DataBoundItem;
                DeleteQuestion(selectedQuestion.Id);
                MessageBox.Show("Xóa Thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuestions();
                PopulateLevelComboBox(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa!");
            }
        }

        private void DeleteQuestion(int id)
        {
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM questionanswer WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();

                }
            }
        }
        #endregion
        #region Thêm 1 câu hỏi
        private void btnThem_Click(object sender, EventArgs e)
        {
            string questionText = txtQues.Text.Trim();
            string answersText = txtAnsw.Text.Trim();
            string correctAnswerText = txtCorrectAns.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(questionText))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(answersText))
            {
                MessageBox.Show("Vui lòng nhập các đáp án (dùng dấu phẩy để phân tách)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(correctAnswerText, out int correctAnswerIndex) || correctAnswerIndex < 0)
            {
                MessageBox.Show("Đáp án đúng phải là một số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse answers
            List<string> answers = answersText.Split(',').Select(a => a.Trim()).ToList();
            if (correctAnswerIndex >= answers.Count)
            {
                MessageBox.Show("Đáp án đúng phải nằm trong danh sách các đáp án đã nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add to the database
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO questionanswer (Question, Answer, CorrectAnswer) VALUES (@Question, @Answer, @CorrectAnswer)";
                    command.Parameters.AddWithValue("@Question", questionText);
                    command.Parameters.AddWithValue("@Answer", JsonConvert.SerializeObject(answers));
                    command.Parameters.AddWithValue("@CorrectAnswer", correctAnswerIndex);

                    command.ExecuteNonQuery();
                }
            }

            // Refresh UI
            MessageBox.Show("Câu hỏi đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadQuestions(); // Reload questions in the DataGridView
            PopulateLevelComboBox(); // Update level combo box
        }
        #endregion

        private void checkSort_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = checkSort.Checked;
        }
        public void UpdateCheckSortStatus()
        {
            checkSort.Checked = false; // Cập nhật cả trạng thái hiển thị của checkbox
        }

    }
}
