package org.example;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;


public class Main {
    public static void main(String[] args) {
        String url = "jdbc:oracle:thin:@oracle.fiap.com.br:1521:orcl";
        String user = "rm96696";
        String password = "210503";

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            System.out.println("Conexão estabelecida com sucesso!");


            String queryCategoria = "SELECT * FROM Categoria";
            System.out.println("Dados da tabela Categoria:");
            exibirDadosTabela(conn, queryCategoria);


            String queryProduto = "SELECT * FROM Produto";
            System.out.println("\nDados da tabela Produto:");
            exibirDadosTabela(conn, queryProduto);

            String queryCliente = "SELECT * FROM Cliente";
            System.out.println("\nDados da tabela Cliente:");
            exibirDadosTabela(conn, queryCliente);

            String queryPedido = "SELECT * FROM Pedido";
            System.out.println("\nDados da tabela Pedido:");
            exibirDadosTabela(conn, queryPedido);

            String queryItemPedido = "SELECT * FROM ItemPedido";
            System.out.println("\nDados da tabela ItemPedido:");
            exibirDadosTabela(conn, queryItemPedido);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static void exibirDadosTabela(Connection conn, String query) {
        try (PreparedStatement pstmt = conn.prepareStatement(query)) {
            ResultSet rs = pstmt.executeQuery();
            ResultSetMetaData metaData = rs.getMetaData();
            int numColumns = metaData.getColumnCount();

            for (int i = 1; i <= numColumns; i++) {
                System.out.print(metaData.getColumnName(i) + (i < numColumns ? ", " : ""));
            }
            System.out.println();

            while (rs.next()) {
                for (int i = 1; i <= numColumns; i++) {
                    System.out.print(rs.getString(i) + (i < numColumns ? ", " : ""));
                }
                System.out.println();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
