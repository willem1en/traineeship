import java.util.Arrays;
import java.util.Scanner;

public class Player {
    String colour;
    char letter;

    Player(String colour) {
        this.colour = colour.toUpperCase();
        this.letter = this.colour.charAt(0);
    }

    public int askForInput(Scanner reader) {
        System.out.println("Player " + this.colour + " can say in which column they would like to add their disc.");
        while (true) {
            char input = reader.next().toUpperCase().charAt(0);
            if (validateInput(input)) {
                return input - 65;
            }
            System.out.println(("Invalid input. Please try again."));
        }
    }

    private boolean validateInput(char input) {
        return Arrays.asList('A', 'B', 'C', 'D', 'E', 'F', 'G').contains(input);
    }
}