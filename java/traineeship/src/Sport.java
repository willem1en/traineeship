public class Sport {
    int players;
    int spelduur;

    Sport() {

    }
}

class Balsport extends Sport {
    static final boolean balsport = true;
    int aantalBallen;
}

class GeenBalSport extends Sport {

}

class JeuDeBoules extends Balsport {
    JeuDeBoules(int players) {
        this.players = players;
        this.aantalBallen = players * 2;
    }
}

class Voetbal extends Balsport {
    Voetbal(int spelduur) {
        this.players = 11;
        this.aantalBallen = 1;
        this.spelduur = spelduur;
    }
}

class Volleybal extends Balsport {
    Volleybal() {
        this.players = 6;
        this.aantalBallen = 1;
    }

}

class Vechtsport extends GeenBalSport {

}

class Schermen extends Vechtsport {

}

