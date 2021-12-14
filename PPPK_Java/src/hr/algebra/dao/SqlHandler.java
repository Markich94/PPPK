/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao;

import hr.algebra.model.Vozac;
import hr.algebra.model.Vozilo;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.util.List;
import javax.sql.DataSource;

/**
 *
 * @author Marko
 */
public class SqlHandler {
    
    private static final String INSERT_VOZACI = "INSERT INTO Vozac (Ime, Prezime, BrojMobitela, BrojVozacke) VALUES (?, ?, ?, ?)";
    private static final String INSERT_VOZILA = "INSERT INTO Vozilo (Marka, Tip, GodinaProizvodnje, InicijalnoStanjeKilometara) VALUES (?, ?, ?, ?)";

    public static void insertVozaci(List<Vozac> vozaci) {
        DataSource dataSource = DataSourceSingleton.getInstance();
        try (Connection con = dataSource.getConnection();
                PreparedStatement stmt = con.prepareStatement(INSERT_VOZACI)){

            for (Vozac vozac : vozaci) {
                stmt.setString(1, vozac.getIme());
                stmt.setString(2, vozac.getPrezime());
                stmt.setString(3, vozac.getBrojMobitela());
                stmt.setString(4, vozac.getBrojVozacke());
                stmt.addBatch();
            }
            
            stmt.executeBatch();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    public static void insertVozila(List<Vozilo> vozila) {
        DataSource dataSource = DataSourceSingleton.getInstance();
        try (Connection con = dataSource.getConnection();
                PreparedStatement stmt = con.prepareStatement(INSERT_VOZILA)){

            for (Vozilo vozilo : vozila) {
                stmt.setString(1, vozilo.getMarka());
                stmt.setString(2, vozilo.getTip());
                stmt.setString(3, vozilo.getGodinaProizvodnje());
                stmt.setString(4, vozilo.getInicijalnoStanjeKilometara());
                stmt.addBatch();
            }
            
            stmt.executeBatch();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
}
