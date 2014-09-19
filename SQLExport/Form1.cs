using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SQLExport.Insert;

namespace SQLExport
{
    public partial class Form1 : Form
    {
        //Strings de conexão e caminhos de arquivo
        public string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        public string filesPath = ConfigurationSettings.AppSettings["FilesPath"];
        public string templateFilePath = ConfigurationSettings.AppSettings["TemplateFilePath"];
        public string templateFile = ConfigurationSettings.AppSettings["TemplateFile"];
        public string excelConnectionString = ConfigurationSettings.AppSettings["ExcelConnectionString"];

        InsertHeader header = new InsertHeader();
        InsertRows insert = new InsertRows();

        Senha senha;

        public Form1(Senha senha)
        {
            this.senha = senha;
            InitializeComponent();
        }

        private void importTXT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            OleDbConnection excel;

            string cud = string.Empty;

            try
            {
                //Abre conexão com o banco
                if (con.State != ConnectionState.Open) con.Open();

                string[] files = Directory.GetFiles(filesPath);
                string fileName;
                StringBuilder values;

                //Valida se existem arquivos de texto
                if (files == null || files.Length == 0)
                    throw new Exception("Diretório vazio!");

                //Valida se o template Excel existe e se está dentro dos padrões de nome (Template.xls)
                if(!File.Exists(templateFilePath + "\\" + templateFile))
                    throw new Exception("Template Excel inexistente ou fora dos padrões de nome (Template.xls)");

                //Lê cada arquivo txt dentro do diretório
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) != ".txt" && Path.GetExtension(file) != ".sql")
                        continue;

                    //Abre o arquivo para leitura
                    StreamReader read = new StreamReader(file);

                    cud = read.ReadToEnd().ToString().ToUpper();                    
                    values = new StringBuilder();
                    fileName = string.Concat(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), DateTime.Now.Millisecond.ToString());
                    
                    //Valida se o comando é realmente uma consulta
                    if (cud.Contains("CREATE TABLE") || cud.Contains("UPDATE") || cud.Contains("DELETE"))
                        throw new Exception("O uso de CREATE, UPDATE ou DELETE não é permitido!");

                    //Cria o comando SQL
                    SqlCommand command = new SqlCommand(read.ReadToEnd(), con);
                    
                    //Popula o DataTable com os valores retornados pelo banco
                    System.Data.DataTable dt = new System.Data.DataTable();
                    new SqlDataAdapter(command).Fill(dt);

                    //Cria uma cópia do template do Excel para inserir os dados retornados pelo banco
                    File.Copy(string.Concat(templateFilePath, "\\", templateFile), string.Concat(templateFilePath, "\\", fileName, ".xls"));

                    //Abre conexão com o arquivo Excel
                    excel = new OleDbConnection(string.Format(excelConnectionString, string.Concat(templateFilePath, "\\", fileName, ".xls")));

                    //Monta a string que será utilizada como comando de inserção do cabeçalho na planilha Excel
                    header.insertHeader(dt, excel);

                    //Monta a string que será utilizada como comando de inserção na planilha Excel
                    insert.insertRows(dt, values, excel);

                    if (excel.State == ConnectionState.Open)
                    {
                        excel.Close();
                        excel.Dispose();
                    }
                }

                MessageBox.Show("Resultado exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao executar o procedimento: " + ex.Message);
            }
            finally 
            {
                if (con.State != ConnectionState.Open) con.Close();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            senha.Close();
        }
    }
}
