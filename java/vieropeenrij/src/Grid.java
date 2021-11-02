import java.util.Scanner;

public class Grid {
    char[][] speelrek = new char[6][7];

    Grid() {
        for(int rij = 0; rij < 6; ++rij) {
            for(int kolom = 0; kolom < 7; ++kolom) {
                this.speelrek[rij][kolom] = ' ';
            }
        }

    }

    void print() {
        System.out.println(" a b c d e f g");
        int rowCount = 6;

        for(int rij = 0; rij < 6; ++rij) {
            String row = "|";

            for(int kolom = 0; kolom < 7; ++kolom) {
                row = row + this.speelrek[rij][kolom] + "|";
            }

            row = row + " " + rowCount;
            System.out.println(row);
            --rowCount;
        }

        System.out.println(" - - - - - - -");
    }

    boolean werpSteen(Player speler, Scanner reader) {
        int worp = speler.askForInput(reader);

        for(int rij = 5; rij > -1; --rij) {
            if (this.speelrek[rij][worp] == ' ') {
                this.speelrek[rij][worp] = speler.letter;
                return true;
            }
        }

        return false;
    }

    boolean klaar() {
        return this.verticaal() || this.horizontaal() || this.diagonaalRechts() || this.diagonaalLinks();
    }

    boolean verticaal() {
        for(int kolom = 0; kolom < 7; ++kolom) {
            char last = ' ';
            int counter = 1;

            for(int rij = 5; rij > -1; --rij) {
                char vak = this.speelrek[rij][kolom];
                if (vak == ' ') {
                    return false;
                }

                if (vak == last) {
                    ++counter;
                    if (counter == 4) {
                        return true;
                    }
                } else {
                    counter = 1;
                    last = vak;
                }
            }
        }

        return false;
    }

    boolean horizontaal() {
        for(int rij = 5; rij > -1; --rij) {
            char last = ' ';
            int counter = 1;

            for(int kolom = 0; kolom < 7; ++kolom) {
                char vak = this.speelrek[rij][kolom];
                if (vak == ' ') {
                    counter = 1;
                } else if (vak == last) {
                    ++counter;
                    if (counter == 4) {
                        return true;
                    }
                } else {
                    counter = 1;
                    last = vak;
                }
            }
        }

        return false;
    }

    boolean diagonaalRechts() {
        for(int rij = 5; rij > -1; --rij) {
            char last = ' ';

            for(int kolom = 0; kolom < 7; ++kolom) {
                int counter = 1;
                char vak = this.speelrek[rij][kolom];
                int vakRij = rij - 1;
                int vakKolom = kolom + 1;
                if (vak == ' ') {
                    boolean var9 = true;
                } else {
                    while(vakRij > -1 & vakKolom < 7) {
                        char diagonaal = this.speelrek[vakRij][vakKolom];
                        if (diagonaal != vak) {
                            break;
                        }

                        ++counter;
                        if (counter == 4) {
                            return true;
                        }

                        --vakRij;
                        ++vakKolom;
                    }
                }
            }
        }

        return false;
    }

    boolean diagonaalLinks() {
        for(int rij = 5; rij > -1; --rij) {
            char last = ' ';

            for(int kolom = 6; kolom > -1; --kolom) {
                int counter = 1;
                char vak = this.speelrek[rij][kolom];
                int vakRij = rij - 1;
                int vakKolom = kolom - 1;
                if (vak == ' ') {
                    boolean var9 = true;
                } else {
                    while(vakRij > -1 & vakKolom > -1) {
                        char diagonaal = this.speelrek[vakRij][vakKolom];
                        if (diagonaal != vak) {
                            break;
                        }

                        ++counter;
                        if (counter == 4) {
                            return true;
                        }

                        --vakRij;
                        --vakKolom;
                    }
                }
            }
        }

        return false;
    }
}
