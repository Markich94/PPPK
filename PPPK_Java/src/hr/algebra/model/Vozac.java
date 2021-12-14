/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

/**
 *
 * @author Marko
 */
public class Vozac {
    
    private int idVozac;
    private String ime;
    private String prezime;
    private String brojMobitela;
    private String brojVozacke;

    public Vozac(String ime, String prezime, String brojMobitela, String brojVozacke) {
        this.ime = ime;
        this.prezime = prezime;
        this.brojMobitela = brojMobitela;
        this.brojVozacke = brojVozacke;
    }

    public Vozac(int iDVozac, String ime, String prezime, String brojMobitela, String brojVozacke) {
        this(ime, prezime, brojMobitela, brojVozacke);
        this.idVozac = iDVozac;
    }

    public int getiDVozac() {
        return idVozac;
    }

    public String getIme() {
        return ime;
    }

    public String getPrezime() {
        return prezime;
    }

    public String getBrojMobitela() {
        return brojMobitela;
    }

    public String getBrojVozacke() {
        return brojVozacke;
    }

    @Override
    public String toString() {
        return String.format("%s %s", ime, prezime);
    }
    
}
