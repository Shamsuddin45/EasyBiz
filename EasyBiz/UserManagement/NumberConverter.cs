using System;

public static class NumberConverter
{
    private static readonly string[] UnitsMap = {
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
        "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };
    
    private static readonly string[] TensMap = {
        "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
    };
    
    public static string ToWords(long number)
    {
        // Handle zero explicitly
        if (number == 0)
            return "zero";

        // Handle negative numbers
        if (number < 0)
        {
            // long.MinValue cannot be made positive using standard negation because 
            // it exceeds long.MaxValue by 1, which would cause an OverflowException.
            if (number == long.MinValue)
                return "minus nine quintillion two hundred twenty-three quadrillion " +
                       "three hundred seventy-two trillion thirty-six billion " +
                       "eight hundred fifty-four million seven hundred seventy-five " +
                       "thousand eight hundred eight";

            return "minus " + ToWords(-number);
        }

        string words = "";

        if ((number / 1_000_000_000_000_000_000) > 0)
        {
            words += ToWords(number / 1_000_000_000_000_000_000) + " quintillion ";
            number %= 1_000_000_000_000_000_000;
        }

        if ((number / 1_000_000_000_000_000) > 0)
        {
            words += ToWords(number / 1_000_000_000_000_000) + " quadrillion ";
            number %= 1_000_000_000_000_000;
        }

        if ((number / 1_000_000_000_000) > 0)
        {
            words += ToWords(number / 1_000_000_000_000) + " trillion ";
            number %= 1_000_000_000_000;
        }

        if ((number / 1_000_000_000) > 0)
        {
            words += ToWords(number / 1_000_000_000) + " billion ";
            number %= 1_000_000_000;
        }

        if ((number / 1_000_000) > 0)
        {
            words += ToWords(number / 1_000_000) + " million ";
            number %= 1_000_000;
        }

        if ((number / 1_000) > 0)
        {
            words += ToWords(number / 1_000) + " thousand ";
            number %= 1_000;
        }

        if ((number / 100) > 0)
        {
            words += ToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            // Process numbers under 100
            if (number < 20)
            {
                words += UnitsMap[number];
            }
            else
            {
                words += TensMap[number / 10];
                if ((number % 10) > 0)
                {
                    // Add hyphen for numbers like twenty-one, forty-five, etc.
                    words += "-" + UnitsMap[number % 10];
                }
            }
        }

        return words.Trim();
    }


    public static readonly string[] SindhiNumbers0To99 = new string[]
    {
  "ٻُڙي",
  "هڪ",
  "ٻه",
  "ٽي",
  "چار",
  "پنج",
  "ڇهه",
  "ست",
  "اٺ",
  "نو",
  "ڏهه",
  "يارنهن",
  "ٻارنهن",
  "تيرنهن",
  "چوڏهن",
  "پندرهن",
  "سورهن",
  "سترهن",
  "ارڙهن",
  "اوڻيهه",
  "ويهه",
  "ايڪيهه",
  "ٻاويهه",
  "ٽيويهه",
  "چوويهه",
  "پنجويهه",
  "ڇويهه",
  "ستاويهه",
  "اٺاويهه",
  "اوڻٽيهه",
  "ٽيهه",
  "ايڪٽيهه",
  "ٻٽيهه",
  "ٽيٽيهه",
  "چوٽيهه",
  "پنجٽيهه",
  "ڇٽيهه",
  "ستٽيهه",
  "اٺٽيهه",
  "اوڻيتاليهه",
  "چاليهه",
  "ايڪيتاليهه",
  "ٻائيتاليهه",
  "ٽيتاليهه",
  "چوئيتاليهه",
  "پنجيتاليهه",
  "ڇائيتاليهه",
  "ستيتاليهه",
  "اٺيتاليهه",
  "اڻونجاهه",
  "پنجاهه",
  "ايڪونجاهه",
  "ٻاونجاهه",
  "ٽيونجاهه",
  "چوونجاهه",
  "پنجونجاهه",
  "ڇاونجاهه",
  "ستونجاهه",
  "اٺونجاهه",
  "اوڻهٺ",
  "سٺ",
  "ايڪهٺ",
  "ٻاهٺ",
  "ٽيهٺ",
  "چوهٺ",
  "پنجهٺ",
  "ڇاهٺ",
  "ستهٺ",
  "اٺهٺ",
  "اوڻهتر",
  "ستر",
  "ايڪهتر",
  "ٻاهتر",
  "ٽيهتر",
  "چوهتر",
  "پنجهتر",
  "ڇاهتر",
  "ستهتر",
  "اٺهتر",
  "اوڻاسي",
  "اسي",
  "ايڪاسي",
  "ٻياسي",
  "ٽياسي",
  "چوراسي",
  "پنجاسي",
  "ڇهاسي",
  "ستاسي",
  "اٺاسي",
  "اوڻانوي",
  "نوي",
  "ايڪانوي",
  "ٻيانوي",
  "ٽيانوي",
  "چورانوي",
  "پنجانوي",
  "ڇهانوي",
  "ستانوي",
  "اٺانوي",
  "نوانوي",
  "سئو"
    };
    public static string ToWordsSindhi(long number)
    {        
        if (number == 0)
            return "ٻُڙي";

        // Handle negative numbers ("ڪاٽُو" means minus/negative)
        if (number < 0)
        {
            // long.MinValue handling. Note: C# 'long' goes up to Quintillions.
            
            // This hardcoded string is a placeholder for an out-of-bounds negative long.
            if (number == long.MinValue)
                return "ڪاٽُو حد کان ٻاهر (Out of bounds)";

            return "ڪاٽُو " + ToWordsSindhi(-number);
        }

        string words = "";

        // Kharab: 100,000,000,000 (11 zeros)
        if ((number / 100_000_000_000) > 0)
        {
            words += ToWordsSindhi(number / 100_000_000_000) + " کرب ";
            number %= 100_000_000_000;
        }

        // Arab: 1,000,000,000 (9 zeros)
        if ((number / 1_000_000_000) > 0)
        {
            words += ToWordsSindhi(number / 1_000_000_000) + " ارب ";
            number %= 1_000_000_000;
        }

        // Crore: 10,000,000 (7 zeros)
        if ((number / 10_000_000) > 0)
        {
            words += ToWordsSindhi(number / 10_000_000) + " ڪروڙ ";
            number %= 10_000_000;
        }

        // Lakh: 100,000 (5 zeros)
        if ((number / 100_000) > 0)
        {
            words += ToWordsSindhi(number / 100_000) + " لک ";
            number %= 100_000;
        }

        // Thousand: 1,000 (3 zeros)
        if ((number / 1_000) > 0)
        {
            words += ToWordsSindhi(number / 1_000) + " هزار ";
            number %= 1_000;
        }

        // Hundred: 100 (2 zeros)
        if ((number / 100) > 0)
        {
            words += ToWordsSindhi(number / 100) + " سئو ";
            number %= 100;
        }

        if (number > 0)
        {
            words += SindhiNumbers0To99[number];
        }

        return words.Trim();
    }
}