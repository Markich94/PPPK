/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra;

import hr.algebra.model.PutniNalog;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDType1Font;

/**
 *
 * @author Marko
 */
public class PPPK_Pdf {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        EntityManagerFactory emf = null;

        try {
            emf = Persistence.createEntityManagerFactory("PPPK_PdfPU");
            //insertData(emf);
            fetchNalozi(emf);
            createPdf(emf);
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (emf != null) {
                emf.close();
            }
        }

    }

    private static void insertData(EntityManagerFactory emf) {
        EntityManager em = null;
        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            PutniNalog pn1 = new PutniNalog(2, 3, "8.7.2021", "1", "Zagreb", "Vodice", 0, 0, 0);
            PutniNalog pn2 = new PutniNalog(3, 4, "9.7.2021", "1", "Zagreb", "Osijek", 0, 0, 0);
            PutniNalog pn3 = new PutniNalog(5, 6, "10.7.2021", "1", "Zagreb", "Karlovac", 0, 0, 0);

            em.persist(pn1);
            em.persist(pn2);
            em.persist(pn3);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    private static void fetchNalozi(EntityManagerFactory emf) {
        EntityManager em = null;
        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            Query query = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
            query.getResultList().forEach(System.out::println);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    private static void createPdf(EntityManagerFactory emf) {
        EntityManager em = null;
        List<PutniNalog> list = new ArrayList<>();
        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            Query query = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
            list = query.getResultList();

            String fileName = "PutniNalozi.pdf";

            PDDocument doc = new PDDocument();
            PDPage page = new PDPage();

            doc.addPage(page);

            PDPageContentStream content = new PDPageContentStream(doc, page);

            content.beginText();
            content.setFont(PDType1Font.HELVETICA, 24);
            content.newLineAtOffset(250, 750);
            content.showText("Putni nalozi");
            content.endText();

            int y = 700;
            
            for (PutniNalog putniNalog : list) {
                content.beginText();
                content.setFont(PDType1Font.HELVETICA, 12);
                content.newLineAtOffset(50, y);
                content.showText(putniNalog.toString());
                content.endText();
                
                y = y - 25;
            }

            content.close();
            doc.save(fileName);
            doc.close();
            System.out.println("PDF location: " + System.getProperty("user.dir"));

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

}
