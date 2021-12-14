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
public class Vozilo {
    
    private int idVozilo;
    private String marka;
    private String tip;
    private String godinaProizvodnje;
    private String inicijalnoStanjeKilometara;

    public Vozilo(String marka, String tip, String godinaProizvodnje, String inicijalnoStanjeKilometara) {
        this.marka = marka;
        this.tip = tip;
        this.godinaProizvodnje = godinaProizvodnje;
        this.inicijalnoStanjeKilometara = inicijalnoStanjeKilometara;
    }

    public Vozilo(int idVozilo, String marka, String tip, String godinaProizvodnje, String inicijalnoStanjeKilometara) {
        this(marka, tip, godinaProizvodnje, inicijalnoStanjeKilometara);
        this.idVozilo = idVozilo;
    }

    public int getIdVozilo() {
        return idVozilo;
    }

    public String getMarka() {
        return marka;
    }

    public String getTip() {
        return tip;
    }

    public String getGodinaProizvodnje() {
        return godinaProizvodnje;
    }

    public String getInicijalnoStanjeKilometara() {
        return inicijalnoStanjeKilometara;
    }

    @Override
    public String toString() {
        return String.format("%s %s", marka, tip);
    }
    
}
