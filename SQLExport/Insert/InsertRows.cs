using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLExport.Insert
{
    class InsertRows
    {
        public void insertRows(DataTable dt, StringBuilder values, OleDbConnection excel)
        {
            OleDbCommand excelCommand;

            try
            {
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    values.Append("INSERT INTO [Plan1$] (");

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        values.Append(col);
                        values.Append(", ");
                    }

                    values.Remove(values.Length - 2, 2);
                    values.Append(")");

                    values.Append(" VALUES (");

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        values.Append("'");
                        values.Append(dt.Rows[row].ItemArray[col].ToString());
                        values.Append("'");
                        values.Append(", ");
                    }

                    values.Remove(values.Length - 2, 2);
                    values.Append(")");

                    //Abre conexão com a planilha Excel
                    if (excel.State != ConnectionState.Open) excel.Open();

                    //Executa a inserção na planilha
                    excelCommand = new OleDbCommand(values.ToString(), excel);
                    excelCommand.ExecuteNonQuery();

                    //Limpa a string utilizada como comando de inserção
                    //values.Clear();
                    //values.Remove(0, values.Length);
                    values.Length = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir na planilha informações retornadas pelo banco de dados: " + ex.Message);
            }
        }
    }
}
