import java.util.Random;
import java.util.Scanner;

public class Game {
    boolean finished = false;
    Grid grid;

    Game() {
        this.initialize();
    }

    private void initialize() {
        this.grid = new Grid();
    }

    public void playGame() {
        Player[] players = createPlayers();
        determineOrder(players);

        Scanner reader = new Scanner(System.in);

        while(true) {
            while(!this.finished) {
                Player[] var7 = spelers;
                int var8 = spelers.length;

                for(int var9 = 0; var9 < var8; ++var9) {
                    Player speler = var7[var9];
                    this.grid.print();
                    this.grid.werpSteen(speler, reader);
                    this.finished = this.grid.klaar();
                    if (this.finished) {
                        this.grid.print();
                        System.out.println("Speler " + speler.colour + " heeft gewonnen, gefeliciteerd!");
                        break;
                    }
                }
            }

            return;
        }
    }

    private void determineOrder(Player[] players) {
        Random r = new Random();
        int a = 0 + r.nextInt(2);

        if (a == 0) {
            return;
        } else {

        }
    }

    private Player[] createPlayers() {
        Player red = new Player("red");
        Player yellow = new Player("yellow");
        return new Player[] {red, yellow};
    }



}
