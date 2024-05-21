using System;
using Oracle.ManagedDataAccess.Client;

class UpdateTables
{
    static void Main()
    {
        string connectionString = "User Id=******;Password=*******;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=********)(PORT=*****)))(CONNECT_DATA=(SID=*****)))";

        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string updateCategoriaQuery = "UPDATE Categoria SET Nome = :NovoNome WHERE CategoriaID = :CategoriaID";
                using (OracleCommand categoriaCommand = new OracleCommand(updateCategoriaQuery, connection))
                {
                    categoriaCommand.Parameters.Add(new OracleParameter("NovoNome", "Nova Categoria"));
                    categoriaCommand.Parameters.Add(new OracleParameter("CategoriaID", 1)); 

                    int rowsAffectedCategoria = categoriaCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffectedCategoria} row(s) updated in Categoria table.");
                }

       
                string updateProdutoQuery = "UPDATE Produto SET Preco = :NovoPreco WHERE ProdutoID = :ProdutoID";
                using (OracleCommand produtoCommand = new OracleCommand(updateProdutoQuery, connection))
                {
                    produtoCommand.Parameters.Add(new OracleParameter("NovoPreco", 500.00));
                    produtoCommand.Parameters.Add(new OracleParameter("ProdutoID", 1)); 

                    int rowsAffectedProduto = produtoCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffectedProduto} row(s) updated in Produto table.");
                }

               

            
                using (OracleCommand commitCommand = connection.CreateCommand())
                {
                    commitCommand.CommandText = "COMMIT";
                    commitCommand.ExecuteNonQuery();
                    Console.WriteLine("Commit realizado com sucesso.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
