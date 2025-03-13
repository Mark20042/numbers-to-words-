using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        //list sa words nga i convert sa number gikan sa 1 padung 19
        List<string> ones = new List<string> { "", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
            "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        //list sa words nga i convert sa number gikan sa 20 padung 90
        List<string> tens = new List<string> { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
            "Seventy", "Eighty", "Ninety" };

        string choice = "";// make sure na walay sulod ang choice

        do//buhaton sa niya ang code
        {
            //mangayo ug input sa user
            Console.WriteLine("\n==========================");
            Console.Write("Enter a number : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("==========================");

            string words = "";// make sure na walay sulod ang words

            int inputNumber = number; // para store sa original nga gi input sa user para ma retrieve sa output

            if (number == 0) //mo check ug zero ang gi input sa user
            {
                words = "Zero"; //gi pass sa words ang Zero nga output
            }
            else if (number < 0) //mo check ug negative number ang gi input sa user
            {
                words = "Negative "; //gi pass sa words ang Negative nga output
                number = -number; // himoun nato positive ang negative number
            }

            //Hundred Millions
            if (number >= 100000000) //mo check ug more than 100 million ang gi input sa user
            {
                int hundredMillions = number / 100000000; //gi divide ang number sa 100 million para makuha ang digits sa hundred millions
                words = words + ones[hundredMillions] + " Hundred "; //gi pass sa words ang hundred millions nga output ug iyahang equivalent nga words sa index sa ones list
                number = number - hundredMillions * 100000000; //gi minusan ang number sa hundred millions para makuha ang remaining digits
            }

            // Ten Millions and Millions
            if (number >= 1000000) //check ug more than 1 million ang gi input sa user
            {
                int millionsPart = number / 1000000; //divide ug 1million ang gi input sa user para makuha ang digits sa millions
                if (millionsPart >= 20) // check if the millions part is 20 or more
                {
                    words = words + tens[millionsPart / 10] + " "; // gikuha sa niya ang first digit sa millions part 
                    if (millionsPart % 10 > 0) //so ang ika duha na digit napud iya gikuha ari to check ug  greater than 0 ba
                    {
                        words = words + ones[millionsPart % 10] + " "; //diri ang ika duha napud na digit iyang gi convert to words
                    }
                }
                else if (millionsPart > 0 && millionsPart < 20) // check siya ug lesser than 20 niya greater than 1
                {
                    words = words + ones[millionsPart] + " "; //conversion padung words kay lesser than 20 man ang digits sa million part
                }
                words = words + "Million "; //add nimo ang word na million 
                number = number - millionsPart * 1000000; // tangtangon nimo ang digits sa ten millions or millions na part
            }

            // Hundred Thousands
            if (number >= 100000) //either naa pay remaining digits or wala or less than 1 million ang gi input sa user
            {
                int hundredThousands = number / 100000; //gi divide ang number sa 100000 para makuha ang digits sa hundred thousands
                words = words + ones[hundredThousands] + " Hundred "; //gi pass sa words ang hundred thousands nga output ug iyahang equivalent nga words sa index sa ones list
                number = number - hundredThousands * 100000; //gi minusan ang number sa hundred thousands para makuha ang remaining digits
            }

            // Ten Thousands and Thousands
            if (number >= 1000) //
            {
                int thousandsPart = number / 1000; //kuhaon ang thousands part sa number
                if (thousandsPart >= 20) // mo check ug more than 20 ang thousands part
                {
                    words = words + tens[thousandsPart / 10] + " "; // kuhaon ang una na digit sa thousands part
                    if (thousandsPart % 10 > 0) // e check ang ika duha na digit sa thousands part
                    {
                        words = words + ones[thousandsPart % 10] + " "; // kuhaon ang ika duha na digit sa thousands part
                    }
                }
                else if (thousandsPart > 0 && thousandsPart < 20) //check ug less than 20 ang thousands part
                {
                    words = words + ones[thousandsPart] + " "; // kuhaon ang equivalent nga words sa index sa ones list
                }
                words = words + "Thousand "; // e add ang word na Thousand
                number = number - thousandsPart * 1000; // remove ang thousands part sa number 
            }

            // Hundreds
            if (number >= 100)//mo check ug more than 100 ang gi input sa user or naa pay remaining digits
            {
                int hundreds = number / 100;//gi divide ang number sa 100 para makuha ang digits sa hundreds
                words = words + ones[hundreds] + " Hundred ";//gi pass sa words ang hundreds nga output ug iyahang equivalent nga words sa index sa ones list
                number = number - hundreds * 100;//gi minusan ang number sa hundreds para makuha ang remaining digits
            }

            // Tens and Ones
            if (number > 0)//mo check ug more than 0 ang gi input sa user or naa pay remaining digits
            {
                if (number < 20)//iya e check kung less than 20 ang gi input sa user
                {
                    words = words + ones[number];//ug ang gi input sa user less than 20, gi pass sa words ang equivalent nga words sa index sa ones list
                }
                else
                {
                    int tenth = number / 10;//gi divide ang number sa 10 para makuha ang digits sa tens
                    words = words + tens[tenth];//ug ang gi input sa user more than 20, gi pass sa words ang equivalent nga words sa index sa tens list

                    if ((number % 10) > 0)//mo check ug naa pay remaining digits 
                    {
                        int wew = number % 10;
                        words = words + " " + ones[wew];//ug naa pay remaining digits, gi pass sa words ang equivalent nga words sa index sa ones list
                    }
                }
            }

            //output sa equivalent nga words sa gi input sa user ug para ma lower case ang mga list sa words
            Console.WriteLine($"\n{inputNumber} if converted to words is :\n{words.ToLower()}");


            //pilianan sa user kung gusto pa siya mag input ug number
            Console.WriteLine("\n===========================");
            Console.WriteLine("Choices : ");
            Console.WriteLine("y : for another operation ");
            Console.WriteLine("any : any character to exit");
            Console.Write("Do you want to enter another number? : ");
            choice = Console.ReadLine().ToLower();

        } while (choice == "y");//ug y ang pilion niya mo loop ang code if dili y, mo exit na ang program

        Console.WriteLine("\nExiting the program");//mao ni output ug dili y ang e enter sa user

    }
}