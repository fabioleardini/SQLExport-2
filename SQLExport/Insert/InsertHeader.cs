using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLExport.Insert
{
    class InsertHeader
    {
        public void insertHeader(DataTable dt, OleDbConnection excel)
        {
            OleDbCommand excelCommand;
            StringBuilder columns = new StringBuilder();
            StringBuilder header = new StringBuilder();
            string command = string.Empty;

            try
            {
                foreach (DataColumn column in dt.Columns)
                {
                    columns.Append("'");
                    columns.Append(column.ColumnName).Append("'");
                    columns.Append(", ");
                }
                columns.Remove(columns.Length - 2, 2);

                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    header.Append(col.ToString());
                    header.Append(", ");
                }
                header.Remove(header.Length - 2, 2);

                command = "INSERT INTO [Plan1$] (" + header.ToString() + ") VALUES (" + columns.ToString() + ")";

                //Abre conexão com a planilha Excel
                if (excel.State != ConnectionState.Open) excel.Open();

                //Executa a inserção na planilha
                excelCommand = new OleDbCommand(command, excel);
                excelCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir informações de cabeçalho na planilha : " + ex.Message);
            }
        }
    }
}