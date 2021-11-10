package org.nagarro;

public class StringCalculator {
    public int add(String input) {

        String[] numbersToAdd = input.split(",");

        int sum = 0;
        for (String number : numbersToAdd) {
            sum += Integer.parseInt(number);
        }
        return sum;
    }
}
