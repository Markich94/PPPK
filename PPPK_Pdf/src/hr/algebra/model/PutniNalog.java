/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 *
 * @author Marko
 */
@Entity
@Table(name="PutniNalog")
public class PutniNalog implements Serializable{
    
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="IDPutniNalog")
    private int id;
    
    @Column(name="VozacID")
    private int vozacId;
    
    @Column(name="VoziloID")
    private int voziloId;
    
    @Column(name="Datum")
    private String datum;
    
    @Column(name="Tip")
    private String tip;
    
    @Column(name="KoordinataA")
    private String koordinataA;
    
    @Column(name="KoordinataB")
    private String koordinataB;
    
    @Column(name="PrijedeniKilometri")
    private int prijedeniKilometri;
    
    @Column(name="ProsjecnaBrzina")
    private int prosjecnaBrzina;
    
    @Column(name="PotrosenoGorivo")
    private int potrosenoGorivo;

    public PutniNalog() {
    }

    public PutniNalog(int id, int vozacId, int voziloId, String datum, String tip, String koordinataA, String koordinataB, int prijedeniKilometri, int prosjecnaBrzina, int potrosenoGorivo) {
        this.id = id;
        this.vozacId = vozacId;
        this.voziloId = voziloId;
        this.datum = datum;
        this.tip = tip;
        this.koordinataA = koordinataA;
        this.koordinataB = koordinataB;
        this.prijedeniKilometri = prijedeniKilometri;
        this.prosjecnaBrzina = prosjecnaBrzina;
        this.potrosenoGorivo = potrosenoGorivo;
    }

    public PutniNalog(int vozacId, int voziloId, String datum, String tip, String koordinataA, String koordinataB, int prijedeniKilometri, int prosjecnaBrzina, int potrosenoGorivo) {
        this.vozacId = vozacId;
        this.voziloId = voziloId;
        this.datum = datum;
        this.tip = tip;
        this.koordinataA = koordinataA;
        this.koordinataB = koordinataB;
        this.prijedeniKilometri = prijedeniKilometri;
        this.prosjecnaBrzina = prosjecnaBrzina;
        this.potrosenoGorivo = potrosenoGorivo;
    }
    
    

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getVozacId() {
        return vozacId;
    }

    public void setVozacId(int vozacId) {
        this.vozacId = vozacId;
    }

    public int getVoziloId() {
        return voziloId;
    }

    public void setVoziloId(int voziloId) {
        this.voziloId = voziloId;
    }

    public String getDatum() {
        return datum;
    }

    public void setDatum(String datum) {
        this.datum = datum;
    }

    public String getTip() {
        return tip;
    }

    public void setTip(String tip) {
        this.tip = tip;
    }

    public String getKoordinataA() {
        return koordinataA;
    }

    public void setKoordinataA(String koordinataA) {
        this.koordinataA = koordinataA;
    }

    public String getKoordinataB() {
        return koordinataB;
    }

    public void setKoordinataB(String koordinataB) {
        this.koordinataB = koordinataB;
    }

    public int getPrijedeniKilometri() {
        return prijedeniKilometri;
    }

    public void setPrijedeniKilometri(int prijedeniKilometri) {
        this.prijedeniKilometri = prijedeniKilometri;
    }

    public int getProsjecnaBrzina() {
        return prosjecnaBrzina;
    }

    public void setProsjecnaBrzina(int prosjecnaBrzina) {
        this.prosjecnaBrzina = prosjecnaBrzina;
    }

    public int getPotrosenoGorivo() {
        return potrosenoGorivo;
    }

    public void setPotrosenoGorivo(int potrosenoGorivo) {
        this.potrosenoGorivo = potrosenoGorivo;
    }

    @Override
    public String toString() {
        return koordinataA + " - " + koordinataB + ", " + datum;
    }
    
    
    
}
