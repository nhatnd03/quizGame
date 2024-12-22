using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using Newtonsoft.Json;

namespace quizGame
{
    public partial class Form1 : Form
    {

        private System.Media.SoundPlayer correctSoundPlayer;
        private System.Media.SoundPlayer errorSoundPlayer;


        int correctAnswer;
        int questionNumber = 1;
        int score = 0;
        int percentage;
        int totalQuestions;
        private List<QuestionAndAnswers> questions = new List<QuestionAndAnswers>();
        private int currentQuestionIndex = 0;
        private FormLevel formLevel;

        public Form1(FormLevel formLevel)
        {
            InitializeComponent();
            this.formLevel = formLevel; // Khởi tạo formLevel
           // this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            correctSoundPlayer = new System.Media.SoundPlayer("correct-156911.wav");
            errorSoundPlayer = new System.Media.SoundPlayer("error-8-206492.wav");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

        }
        public void StartQuiz(int level, bool shuffle)
        {
            // Lấy câu hỏi theo level
            questions = GetQuestionsByLevel(level);

            if (questions == null || questions.Count == 0)
            {
                MessageBox.Show($"Không có câu hỏi cho level {level}!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xáo trộn câu hỏi nếu được yêu cầu
            if (shuffle)
            {
                Random rng = new Random();
                var originalAnswers = questions[currentQuestionIndex].Answers;
                questions[currentQuestionIndex].Answers = originalAnswers.OrderBy(x => rng.Next()).ToList();
                questions[currentQuestionIndex].CorrectAnswer =
                    questions[currentQuestionIndex].Answers.IndexOf(originalAnswers[questions[currentQuestionIndex].CorrectAnswer]);
            }

            // Cập nhật UI
            questions[0].Level = level;
            totalQuestions = questions.Count;
            currentQuestionIndex = 0;
            score = 0;

            // Hiển thị câu hỏi đầu tiên
            askQuestion(questions);
            UpdateProgressLabel(level);
        }

        private List<QuestionAndAnswers> GetQuestionsByLevel(int level)
        {
            List<QuestionAndAnswers> levelQuestions = new List<QuestionAndAnswers>();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=quiziz.db"))
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(
                        "SELECT * FROM questionanswer WHERE Level = @Level", conn))
                    {
                        command.Parameters.AddWithValue("@Level", level);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                levelQuestions.Add(new QuestionAndAnswers
                                {
                                    Id = reader.GetInt32(0),
                                    Questions = reader.GetString(1),
                                    Answers = JsonConvert.DeserializeObject<List<string>>(reader.GetString(2)),
                                    CorrectAnswer = reader.GetInt32(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return levelQuestions;
        }


        private void askQuestion(List<QuestionAndAnswers> questions)
        {
            if (currentQuestionIndex >= questions.Count || currentQuestionIndex < 0)
            {
                return;
            }

            var question = questions[currentQuestionIndex];
            lblQuestion.Text = "Câu " + (currentQuestionIndex + 1) + ": " + question.Questions;
            resetButtonColors();

            if (question.Answers.Count >= 4)
            {
                button1.Text = question.Answers[0];
                button2.Text = question.Answers[1];
                button3.Text = question.Answers[2];
                button4.Text = question.Answers[3];
            }
            else
            {
                button1.Text = question.Answers[0];
                button2.Text = question.Answers.Count > 1 ? question.Answers[1] : "";
                button3.Text = question.Answers.Count > 2 ? question.Answers[2] : "";
                button4.Text = question.Answers.Count > 3 ? question.Answers[3] : "";
            }
            button1.Tag = 0;
            button2.Tag = 1;
            button3.Tag = 2;
            button4.Tag = 3;
            correctAnswer = question.CorrectAnswer;
            UpdateProgressLabel(question.Level);
        }

        private void resetButtonColors()
        {
            button1.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
            button2.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
            button3.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
            button4.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;
            int selectedAnswer = Convert.ToInt32(senderObject.Tag);
            DisableAnswerButtons();
            if (selectedAnswer == correctAnswer)
            {
                senderObject.BackColor = Color.LightGreen;
                correctSoundPlayer.Play();
                score++;
                
            }
            else
            {
                senderObject.BackColor = Color.Red;
                errorSoundPlayer.Play();
                highlightCorrectAnswer();
            }
         //   MessageBox.Show("CorrectAnswer: " + correctAnswer.ToString());
            await Task.Delay(1300);
            nextQuestion();

        }
        private void highlightCorrectAnswer()
        {
            switch (correctAnswer)
            {
                case 0:
                    button1.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 1:
                    button2.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 2:
                    button3.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 3:
                    button4.BackColor = System.Drawing.Color.LightGreen;
                    break;
            }

        }

        private void nextQuestion()
        {
            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                if (currentQuestionIndex > 0)
                {
                    EndQues();
                    score = 0;

                }
                currentQuestionIndex = 0; 
            }
            else
            {
                askQuestion(questions);
            }
            EnableAnswerButtons();
            UpdateProgressLabel(questions.First().Level);
        }
        private void UpdateProgressLabel(int  level)
        {
            lableCau.Text = $"Level {level}\n{currentQuestionIndex + 1}/{GetQuestionsByLevel(level).Count}";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLevel.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formLevel != null && !formLevel.IsDisposed)
            {
                this.Hide();
                formLevel.Show();
            }
        }
        public void EndQues()
        {
            percentage = (score * 100) / questions.Count;
            ShowCustomMessageBox($"Bài kiểm tra đã kết thúc!\nĐiểm số: {score}/{questions.Count}\nPhần trăm: {percentage}%", "Thông báo", MessageBoxIcon.Information);

        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            EndQues();
        }
        private void DisableAnswerButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void EnableAnswerButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void ShowCustomMessageBox(string message, string title, MessageBoxIcon icon)
        {
            Form customMessageBox = new Form();
            customMessageBox.Text = title;
            customMessageBox.Size = new Size(400, 200); 
            customMessageBox.BackColor = Color.LightBlue; 

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(20, 20);
            messageLabel.Font = new Font("Arial", 12);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(150, 100);
            okButton.Click += (sender, e) =>
            {
                customMessageBox.Close();
                this.Hide();
                formLevel.Show();
            };

            customMessageBox.Controls.Add(messageLabel);
            customMessageBox.Controls.Add(okButton);
            customMessageBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            customMessageBox.MaximizeBox = false;
            customMessageBox.MinimizeBox = false;
            customMessageBox.StartPosition = FormStartPosition.CenterScreen;
            customMessageBox.Icon = SystemIcons.Information;
            customMessageBox.ShowDialog();
        }
    }
}
