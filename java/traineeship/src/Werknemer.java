public class Werknemer {
    String name;
    double salaris;
    String functie;
    static int aantalWerknemers = 0;
    int jarenErvaring;

    Werknemer() {}

    Werknemer(String name, double salaris, String functie, int jarenErvaring) {
        this.name = name;
        this.salaris = salaris;
        this.functie = functie;
        this.aantalWerknemers++;
        this.jarenErvaring = jarenErvaring;
    }
}

class Marketing extends Werknemer {
    double marketingBudget;
    int aantalWerknemersMarketing;

    Marketing(String name, double salaris, String functie, int jarenErvaring, double marketingBudget) {
        // super(name, salaris, functie, jarenErvaring);
        this.aantalWerknemersMarketing++;
        this.marketingBudget = marketingBudget;
    }

}

class Developer extends Werknemer {
    String programmeertaal;
    boolean scrumCertificaat;
    int aantalDevelopers = 0;

    Developer(String name, double salaris, String functie, int jarenErvaring, String programmeertaal, boolean scrumCertificaat) {
        super(name, salaris, functie, jarenErvaring);
        this.aantalDevelopers++;
        this.programmeertaal = programmeertaal;
        this.scrumCertificaat = scrumCertificaat;
    }
}
