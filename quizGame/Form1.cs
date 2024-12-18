using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using Newtonsoft.Json;  // Add this namespace for JSON deserialization

namespace quizGame
{
    public partial class Form1 : Form
    {
        // Variables for the quiz game
        int correctAnswer;
        int questionNumber = 1;
        int score = 0;
        int percentage;
        int totalQuestions;
        private List<QuestionAndAnswers> questions = new List<QuestionAndAnswers>();
        private int currentQuestionIndex = 0;
        

        public int SelectedLevel { get; set; } = 1;

        private StartForm startForm;

        public Form1(StartForm startForm)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Ngăn resize
            this.MaximizeBox = false; // Ẩn nút phóng to
            this.MinimizeBox = true; // Hiển thị nút thu nhỏ (tuỳ chọn)

            this.startForm = startForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SQLiteConnection conn = new SQLiteConnection("Data Source=quiziz.db");

            try
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM questionanswer", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                questions = new List<QuestionAndAnswers>();

                while (reader.Read())
                {
                    // Read the data from the database
                    int id = reader.GetInt32(0);  // Id column
                    string questionText = reader.GetString(1);
                    string answerJson = reader.GetString(2);
                    int correctAnswerIndex = reader.GetInt32(3);

                    List<string> answers = JsonConvert.DeserializeObject<List<string>>(answerJson);

                    questions.Add(new QuestionAndAnswers
                    {
                        Id = id,
                        Questions = questionText,
                        Answers = answers,
                        CorrectAnswer = correctAnswerIndex
                    });
                }

                totalQuestions = questions.Count;


                // Đặt currentQuestionIndex về 0 trước khi hiển thị câu hỏi đầu tiên
                currentQuestionIndex = 0;

                // Gọi phương thức askQuestion với danh sách câu hỏi
                askQuestion(questions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void askQuestion(List<QuestionAndAnswers> questions)
        {
            if (currentQuestionIndex >= questions.Count || currentQuestionIndex < 0)
            {
                return; // Không cần hiển thị MessageBox ở đây nữa
            }

            var question = questions[currentQuestionIndex];
            lblQuestion.Text = "Câu "+(currentQuestionIndex+1)+": " +question.Questions;
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

            correctAnswer = question.CorrectAnswer;
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

            if (selectedAnswer == correctAnswer)
            {
                senderObject.BackColor = Color.LightGreen;
                score++;
 
            }
            else
            {
                senderObject.BackColor = Color.Red;
                highlightCorrectAnswer();
            }
                await Task.Delay(1500);
                nextQuestion();
        }

        private void highlightCorrectAnswer()
        {
            switch (correctAnswer)
            {
                case 1:
                    button1.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 2:
                    button2.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 3:
                    button3.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case 4:
                    button4.BackColor = System.Drawing.Color.LightGreen;
                    break;
            }
        }

        private void nextQuestion()
        {
            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                // Quiz completed
                percentage = (score * 100) / questions.Count;
                MessageBox.Show($"Quiz Ended!\nScore: {score}/{questions.Count}\nPercentage: {percentage}%");
                score = 0;
                currentQuestionIndex = 0; // Reset lại index
            }
            else
            {
                askQuestion(questions);
            }
        }
        public void UpdateQuestions(List<QuestionAndAnswers> newQuestions, int level)
        {
            questions = newQuestions;
            SelectedLevel = level;

            // Reset trạng thái trò chơi
            ResetQuiz();
        }

        public void ResetQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;          
            if (questions != null && questions.Count > 0)
            {
                askQuestion(questions);
            }
            else
            {
                MessageBox.Show("Không có câu hỏi cho level này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var currentQuestion = questions[currentQuestionIndex];
                lblQuestion.Text = currentQuestion.Questions;
                button1.Text = currentQuestion.Answers[0];
                button2.Text = currentQuestion.Answers[1];
                button3.Text = currentQuestion.Answers[2];
                button4.Text = currentQuestion.Answers[3];
                correctAnswer = currentQuestion.CorrectAnswer;
            }
            else
            {
                MessageBox.Show("Bạn đã hoàn thành level này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var parentForm = this.Owner as StartForm;
            if (parentForm != null)
            {
                parentForm.UpdateCheckSortStatus(); // Truyền trạng thái isChecked từ StartForm

                parentForm.Show();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            var parentForm = this.Owner as StartForm;
            if (parentForm != null)
            {
                parentForm.UpdateCheckSortStatus(); // Truyền trạng thái isChecked từ StartForm
                parentForm.Show();
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Tạo một hiệu ứng bóng mờ cho Button
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn = (Button)c;

                    // Vẽ bóng đổ
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), btn.Bounds.X + 10, btn.Bounds.Y + 10, btn.Width, btn.Height);
                }
            }
        }

    }
}
