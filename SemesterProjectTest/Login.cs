using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjectTest
{
    public partial class Login : Form
    {

        static MongoClient dbClient = new MongoClient("mongodb://localhost:27017/");
        static IMongoDatabase db = dbClient.GetDatabase("Restaraunt");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");

        public Login()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e) //this is the username box
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

               var filter = Builders<User>.Filter.Eq("Username", txtUsername.Text) & Builders<User>.Filter.Eq("Password", txtPassword.Text);

    var user = users.Find(filter).FirstOrDefault();
    if (user != null)

    {
        MessageBox.Show("Logged in successfully!");

        if (user.Role == "0")
        {
            var window = new Admin();
            window.Show();
        }

        else if (user.Role == "1")
        {
            var window = new Manager();
            window.Show();
        }

        else
        {
            var window = new Staff();
            window.Show();
        }
    }
    else
    {
        MessageBox.Show("Try logging in again.");
        }
    }
}

    class User
    {
        [BsonId]

        [BsonElement("ID")]
        public int ID { get; set; }

        [BsonElement("Username")]

        public string Username { get; set; }

        [BsonElement("Password")]

        public string Password { get; set; }

        [BsonElement("Role")]

        public string Role { get; set; }
    }

}
