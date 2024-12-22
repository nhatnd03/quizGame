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
using quizGame.Resources.Custom;
using System.Reflection.Emit;


namespace quizGame
{
    public partial class StartForm : Form
    {

        private Form2 _form2;
        private string dbPath = "quiziz.db";
        private bool isClosingToForm2 = false;
        public StartForm(Form2 form2)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            _form2 = form2;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Ngăn resize
            this.MaximizeBox = false; // Ẩn nút phóng to
            this.MinimizeBox = true; // Hiển thị nút thu nhỏ (tuỳ chọn)
            CreateDatabase();
            LoadQuestions();
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
                txtLevel.Text = selectedQuestion.Level.ToString();
                
            }
            else
            {
                txtLevel.Clear();
                txtQues.Clear();
                txtAnsw.Clear();
                txtCorrectAns.Clear();
            }
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
                                                CorrectAnswer INTEGER NOT NULL,
                                                Level INTEGER NOT NULL
                                            );";
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
                            command.CommandText = "INSERT INTO questionanswer (Question, Answer, CorrectAnswer, Level) VALUES (@Question, @Answer, @CorrectAnswer, @Level)";
                            command.Parameters.AddWithValue("@Question", "");
                            command.Parameters.AddWithValue("@Answer", "");
                            command.Parameters.AddWithValue("@CorrectAnswer", 0);
                            command.Parameters.AddWithValue("@Level", 0);

                            string question = "";
                            List<string> answers = new List<string>();
                            int correctAnswer = 0;
                            int level = 0;

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
                                        command.Parameters["@Level"].Value = level;
                                        command.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        throw new Exception("Đáp án đúng không hợp lệ!");
                                    }
                                    question = "";
                                    answers.Clear();
                                }
                                else if (text.StartsWith("Level:"))
                                {
                                    level = int.Parse(text.Substring(6).Trim());
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
                            QuestionAndAnswers question = new QuestionAndAnswers
                            {
                                Id = reader.GetInt32(0),
                                Questions = reader.GetString(1),
                                Answers = JsonConvert.DeserializeObject<List<string>>(reader.GetString(2)),
                                CorrectAnswer = reader.GetInt32(3),
                                Level = reader.GetInt32(4)
                            };
                            question.AnswersString = QuestionAndAnswers.JsonStringToString(reader.GetString(2));
                            questions.Add(question);
                        }

                        dgvQuestions.AutoGenerateColumns = false;
                        dgvQuestions.Columns.Clear();

                        dgvQuestions.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Questions",
                            HeaderText = "Câu hỏi"
                        });

                        dgvQuestions.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "AnswersString",
                            HeaderText = "Đáp án"
                        });

                        dgvQuestions.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "CorrectAnswer",
                            HeaderText = "Đáp án đúng"
                        });

                        dgvQuestions.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Level",
                            HeaderText = "Độ khó"
                        });

                        dgvQuestions.DataSource = questions;
                        dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvQuestions.AllowUserToAddRows = false;
                    }
                }
            }
        }
        private void StartForm_Load(object sender, EventArgs e)
        {
            LoadQuestions(); // Load questions when the form loads
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
                    command.CommandText = "UPDATE questionanswer SET Question = @Question, Answer = @Answer, CorrectAnswer = @CorrectAnswer, Level = @Level WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Question", txtQues.Text);
                    command.Parameters.AddWithValue("@Answer", JsonConvert.SerializeObject(question.Answers));
                    command.Parameters.AddWithValue("@CorrectAnswer", int.Parse(txtCorrectAns.Text));
                    command.Parameters.AddWithValue("@Id", question.Id);
                    command.Parameters.AddWithValue("@Level",int.Parse(txtLevel.Text));
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
                LoadQuestions();
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
            if (!string.IsNullOrWhiteSpace(txtQues.Text) && !string.IsNullOrWhiteSpace(txtAnsw.Text) && !string.IsNullOrWhiteSpace(txtCorrectAns.Text) && !string.IsNullOrWhiteSpace(txtLevel.Text))
            {
                string connectionString = $"Data Source={dbPath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO questionanswer (Question, Answer, CorrectAnswer, Level) VALUES (@Question, @Answer, @CorrectAnswer, @Level)";
                        command.Parameters.AddWithValue("@Question", txtQues.Text);
                        command.Parameters.AddWithValue("@Answer", JsonConvert.SerializeObject(txtAnsw.Text.Split(';').Select(a => a.Trim()).ToList()));
                        command.Parameters.AddWithValue("@CorrectAnswer", int.Parse(txtCorrectAns.Text));
                        command.Parameters.AddWithValue("@Level", int.Parse(txtLevel.Text));
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLevel.Clear();
                        txtQues.Clear();
                        txtAnsw.Clear();
                        txtCorrectAns.Clear();
                       
                        LoadQuestions();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin câu hỏi, đáp án và đáp án đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_form2 != null && !_form2.IsDisposed)
            {
                e.Cancel = true;
                this.Hide(); 
                _form2.Show(); 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_form2 != null && !_form2.IsDisposed)
            {
                this.Hide(); // Ẩn form hiện tại
                _form2.Show(); // Quay lại Form2
            }
        }


    }
}
