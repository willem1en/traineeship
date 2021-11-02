import java.util.Random;
import java.util.Scanner;

public class Code {
    char[] code = new char[4];
    char[] codeArr = new char[4];
    char[] inpArr = new char[4];
    boolean solved = false;

    Code() {
        initialise();
    }

    public void playGame() {
        while (!solved) {
            askForInput();
        }
    }

    private void initialise() {
        Random random = new Random();
        for (int i = 0; i < 4; i++) {
            code[i] = (char) ('a' + random.nextInt(6));
        }
    }

    private void askForInput() {
        Scanner reader = new Scanner(System.in);
        System.out.println("Enter four characters from a to f: ");
        String input = reader.next();
        char inp = reader.next().charAt(0);
        testInput(input);
        // reader.close();
    }

    private void testInput(String input) {
        for (int i = 0; i < 4; i++) {
            this.inpArr[i] = input.charAt(i);
        }

        this.codeArr = code.clone();
        int corr = correctCounter();
        int wrong = wrongPlaceCounter();
        testSolved(corr, wrong);
    }

    private void testSolved(int corr, int wrong) {
        if (corr == 4) {
            System.out.println("Congratulations! You've cracked the code.");
            this.solved = true;
        } else {
            System.out.println("Correct: " + corr);
            System.out.println("Wrong place: " + wrong);
        }
    }

    private int wrongPlaceCounter() {
        int wrongPlaceCounter = 0;
        for (int i = 0; i < 4; i++) {
            for (int a = 0; a < 4; a++) {
                if (i == a) {
                    continue;
                }
                if (inpArr[i] == codeArr[a]) {
                    wrongPlaceCounter++;
                    inpArr[i] = 'x';
                    codeArr[a] = 'y';
                }
            }
        }
        return wrongPlaceCounter;
    }

    private int correctCounter() {
        int correctCounter = 0;
        for (int i = 0; i < 4; i++) {
            if (codeArr[i] == inpArr[i]) {
                this.inpArr[i] = 'x';
                this.codeArr[i] = 'y';
                correctCounter++;
            }
        }
        return correctCounter;
    }
}
