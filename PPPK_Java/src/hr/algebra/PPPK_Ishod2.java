/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra;

import hr.algebra.dao.SqlHandler;
import hr.algebra.model.Vozac;
import hr.algebra.model.Vozilo;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Marko
 */
public class PPPK_Ishod2 {
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        List<Vozac> vozaci = getVozaci();
        List<Vozilo> vozila = getVozila();
        
        SqlHandler.insertVozaci(vozaci);
        SqlHandler.insertVozila(vozila);
    }
    
    public static List<Vozac> getVozaci() {
        List<Vozac> list = new ArrayList<>();
        
        list.add(new Vozac("Marko", "Manjerovic", "0911114994", "26598454"));
        list.add(new Vozac("Maja", "Manjerovic", "0996451418", "69581122"));
        list.add(new Vozac("Ante", "Manjerovic", "0996985214", "3694815"));
        list.add(new Vozac("Ivan", "Manjerovic", "099874358", "6491551"));
        
        return list;
    }
    
    public static List<Vozilo> getVozila() {
        List<Vozilo> list = new ArrayList<>();
        
        list.add(new Vozilo("Audi", "A6", "2020", "2698"));
        list.add(new Vozilo("Mercedes", "C220d", "2018", "45239"));
        list.add(new Vozilo("BMW", "M3", "2008", "115654"));
        list.add(new Vozilo("VW", "Arteon", "2021", "15"));
        
        return list;
    }
    
}
