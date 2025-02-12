using L2O___D09;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Find all products that are out of stock.
            var outofStockProducts = ListGenerators.ProductList
                .Where(p => p.UnitsInStock == 0)
                .ToList();
            //Show(outofStockProducts);

            //Find all products that are in stock and cost more than 3.00 per unit.
            var stock3Unit = ListGenerators.ProductList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                .ToList();
            //Show(stock3Unit);

            //Returns digits whose name is shorter than their value.
            string[] digitsName = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsShorter = digitsName
                .Where((p, i) => p.Length < i).ToList();
            //Show(digitsShorter);

            //Get first Product out of Stock
            var firstProd = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            //Console.WriteLine(firstProd);

            //Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var first1000Prod = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(first1000Prod);

            //Retrieve the second number greater than 5 
            int[] Num2ndArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNum = Num2ndArr.OrderByDescending(n => n).Where(n => n > 5).ElementAtOrDefault(1);
            //Console.WriteLine(secondNum);

            //Find the unique Category names from Product List
            var uniqueCats = ListGenerators.ProductList.Select(p => p.Category).Distinct().ToList();
            //Show(uniqueCats);

            //Produce a Sequence containing the unique first letter from both product and customer names.
            var mergedLists1stLetters = ListGenerators.ProductList
                .Select(p => p.ProductName)
                .Union(ListGenerators.CustomerList.Select(c => c.CompanyName))
                .Select(merged => merged[0])
                .Distinct().ToList();
            //Show(mergedLists1stLetters);

            //Create one sequence that contains the common first letter from both product and customer names.
            var mergedCommon1stLetters = ListGenerators.ProductList
                .Select(p => p.ProductName)
                .Join(ListGenerators.CustomerList.Select(c => c.CompanyName), p => p[0] , c => c[0] , (p,c) => p[0])
                .Distinct().ToList();
            //Show(mergedCommon1stLetters);

            //Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var mergedListsExcept = ListGenerators.ProductList
                .Select(p => p.ProductName[0])
                .Except(ListGenerators.CustomerList.Select(c => c.CompanyName[0]))
                .ToList();
            //Show(mergedListsExcept);

            //Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
            var lastThreeChars = ListGenerators.ProductList
                .Select(p => string.Join("",p.ProductName.TakeLast(3)))
                .Concat(ListGenerators.CustomerList.Select(c => string.Join("", c.CompanyName.TakeLast(3))))
                .ToList();
            //Show(lastThreeChars);

            //Uses Count to get the number of odd numbers in the array
            int[] OddCountArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var oddNums = OddCountArr.Count(n => n % 2 == 1);
            //Console.WriteLine(oddNums);

            //Return a list of customers and how many orders each has
            var customersOrder = ListGenerators.CustomerList
                .Select(c => $"Name: {c.CompanyName} Orders :{c.Orders.Count()}")
                .ToList();
            //Show(customersOrder);

            //Return a list of categories and how many products each has
            var catProducts = ListGenerators.ProductList
                                .GroupBy(p => p.Category)
                                .Select(p => $"Category : {p.Key} Products : {p.Count()}")
                                .ToList();
            //Show(catProducts);

            //Get the total of the numbers in an array
            int[] totalArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var totalNumsInArr = totalArr.Sum();
            //Console.WriteLine(totalNumsInArr);

            //Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            using (TextReader textReader = File.OpenText("dictionary_english.txt"))
            {
                string line;
                List<string> words = new List<string>();
                while ((line = textReader.ReadLine()) != null)
                {
                    words.Add(line);
                }
                var totalCharacters = words.Sum(p => p.Length);
                var shortestWords = words.Min(p => p.Length);
                var longestWords = words.Max(p => p.Length);
                var avgWords = words.Average(p => p.Length);
                var containEI = words.Any(p => p.Contains("ei"));
                //Console.WriteLine(totalCharacters);
                //Console.WriteLine(shortestWords);
                //Console.WriteLine(longestWords);
                //Console.WriteLine(avgWords);
                //Console.WriteLine(containEI);
            }

            //Get the total units in stock for each product category.
            var totalUnitsStock = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(p => $"{p.Key} : {p.Sum(unit => unit.UnitsInStock)}")
                                   .ToList();
            //Show(totalUnitsStock);

            //Get the cheapest price among each category's products
            var cheaptestProdCat = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(p => $"{p.Key} || Min Price: {p.Min(price => price.UnitPrice)}")
                                   .ToList();
            //Show(cheaptestProdCat);

            //Get the products with the cheapest price in each category (Use Let)
            var cheaptestProductPerCat = from prod in ListGenerators.ProductList
                                         group prod by prod.Category into prodGroup
                                         let minPrice = prodGroup.Min(p => p.UnitPrice)
                                         from p in prodGroup
                                         where p.UnitPrice == minPrice
                                         select p;


            //Show(cheaptestProductPerCat);

            //Get the most expensive price among each category's products
            var ExpensiveProdCat = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(p => $"{p.Key} || Max Price: {p.Max(price => price.UnitPrice)}")
                                   .ToList();
            //Show(ExpensiveProdCat);

            //Get the products with the most expensive price in each category
            var ExpensiveProductPerCat = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(p => p.MaxBy(price => price.UnitPrice))
                                   .ToList();
            //Show(ExpensiveProductPerCat);

            //Get the average price of each category's products
            var avgProdCat = ListGenerators.ProductList
                                   .GroupBy(p => p.Category)
                                   .Select(p => $"{p.Key} || Average Price: {p.Average(price => price.UnitPrice)}")
                                   .ToList();
            //Show(avgProdCat);

            //Sort a list of products by name
            var sortedByNameProd = ListGenerators.ProductList.OrderBy(p => p.ProductName);
            //Show(sortedByNameProd);

            //Uses a custom comparer to do a case-insensitive sort of the words in an array
            string[] caseInsensitiveArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedInsensitive = caseInsensitiveArr.OrderBy(p => p.ToLower());
            //Show(sortedInsensitive);

            //Sort a list of products by units in stock from highest to lowest.
            var sortedDescProductsPrice = ListGenerators.ProductList.OrderByDescending(p => p.UnitPrice);
            //Show(sortedDescProductsPrice);

            //Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            string[] sortLengthThenNameArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var sortedLengthThenName = sortLengthThenNameArr.OrderBy(p => p.Length).ThenBy(p => p);
            //Show(sortedLengthThenName);

            //Sort first by word length and then by a case-insensitive sort of the words in an array
            string[] sortLengthThenCaseWords = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortLengthThenCase = sortLengthThenCaseWords.OrderBy(p => p.Length).ThenBy(p => p.ToLower());
            //Show(sortLengthThenCase);

            //Sort a list of products, first by category, and then by unit price, from highest to lowest
            var sortedByCatThenPriceDESC = ListGenerators.ProductList
                                            .OrderBy(p => p.Category)
                                            .ThenByDescending(p => p.UnitPrice);
            //Show(sortedByCatThenPriceDESC);

            //Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            string[] sortLengthThenCaseDESCWords = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortLengthThenCaseDESC = sortLengthThenCaseDESCWords.OrderBy(p => p.Length).ThenByDescending(p => p.ToLower());
            //Show(sortLengthThenCaseDESC);

            //Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] reversed2ndIArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var reversed2ndI = reversed2ndIArr.Reverse().Where(r => r.ToLower().ElementAtOrDefault(1) == 'i');
            //Show(reversed2ndI);

            //Get the first 3 orders from customers in Washington
            var orders3 = ListGenerators.CustomerList
                .Where(c => c.City.ToLower() == "washington")
                .SelectMany(r => r.Orders);
            //Show(orders3);

            //Get all but the first 2 orders from customers in Washington
            var ordersbutfirst2 = ListGenerators.CustomerList
                .Where(c => c.City.ToLower() == "washington")
                .SelectMany(r => r.Orders)
                .Skip(2);
            //Show(ordersbutfirst2);

            //Return elements starting from the beginning of the array until a number is hit that is less than its position in the array
            int[] numbersLessThanElementIndexArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numbersLessThanElementIndex = numbersLessThanElementIndexArr.TakeWhile((n, i) => n >= i);
            //Show(numbersLessThanElementIndex);

            //Get the elements of the array starting from the first element divisible by 3.
            int[] numbersDivBy3SkipArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numbersDivBy3Skip = numbersDivBy3SkipArr.SkipWhile(n => n % 3 != 0);
            //Show(numbersDivBy3Skip);

            //Get the elements of the array starting from the first element less than its position.
            int[] numbersLessThanElementSkipArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numbersLessThanElementSkip = numbersLessThanElementSkipArr.SkipWhile((n, i) => n >= i);
            //Show(numbersLessThanElementSkip);

            //Return a sequence of just the names of a list of products.
            var justProdNames = ListGenerators.ProductList.Select(p => p.ProductName);
            //Show(justProdNames);

            //Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            string[] upperAndLowerWordsArr = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var upperAndLowerWords = upperAndLowerWordsArr.Select(p => $"{p.ToUpper()} {p.ToLower()}");
            //Show(upperAndLowerWords);

            //Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            var renamedPrice = ListGenerators.ProductList.Select(p => new { Name = p.ProductName, Price = p.UnitPrice });
            renamedPrice.Select(p => p.Price);

            //Determine if the value of ints in an array match their position in the array.
            int[] indexIsValueArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var indexIsValue = indexIsValueArr.Select((n, i) => n == i ? $"{n}:True" : $"{n}:False");
            //Show(indexIsValue);

            //Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var lessThanPairs = numbersA
                                .SelectMany(b => numbersB,(a,b) => new {First=a,Second=b})
                                .Where(pair => pair.First < pair.Second)
                                .Select(pair => $"{pair.First} is less than {pair.Second}");
            //Show(lessThanPairs);

            //Select all orders where the order total is less than 500.00.
            var orderTotalLessThan500 = ListGenerators.CustomerList.SelectMany(o => o.Orders).Where(o => o.Total < 500);
            //Show(orderTotalLessThan500);

            //Select all orders where the order was made in 1998 or later.
            var ordersMadeAfter1998 = ListGenerators.CustomerList.SelectMany(o => o.Orders)
                                                                    .Where(o => o.OrderDate.Year >= 1998);
            //Show(ordersMadeAfter1998);

            //Return a grouped a list of products only for categories that have at least one product that is out of stock
            var groupedCatWithOneOOS = ListGenerators.ProductList.GroupBy(p => p.Category)
                                                                    .Where(p => p.Any(stock => stock.UnitsInStock == 0))
                                                                    .Select(p => $"Category:{p.Key}\n{string.Join("\n", p)}");
            //Show(groupedCatWithOneOOS);

            //Return a grouped a list of products only for categories that have all of their products in stock.
            var groupedCatWithAllNotOOS = ListGenerators.ProductList.GroupBy(p => p.Category)
                                                                    .Where(p => p.All(stock => stock.UnitsInStock != 0))
                                                                    .Select(p => $"Category:{p.Key}\n{string.Join("\n", p)}");
            //Show(groupedCatWithAllNotOOS);

            //Use group by to partition a list of numbers by their remainder when divided by 5
            int[] reminder5Arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var reminder5 = reminder5Arr.GroupBy(n => n % 5)
                                        .Select(n => $"Numbers with a remainder of {n.Key} when divided by 5:\n{string.Join("\n", n)}");
            //Show(reminder5);

            //Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
            using (TextReader textReader = File.OpenText("dictionary_english.txt"))
            {
                List<string> strings = new();
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    strings.Add(line);
                }
                var stringsPart = strings.GroupBy(s => s[0])
                                            .Select(s => $"{s.Key}\n\t{string.Join("\n\t", s)}");
                //Show(stringsPart);
            }


            //Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var final = Arr.Select(s => s.Trim())
                            .GroupBy(s => string.Join("",s.Order().ToArray()))
                            .Select(s => $"----\n{string.Join("\n", s)}\n-----\n");
            //Show(final);








        }
        static void Show(IEnumerable collection)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            foreach (var item in collection)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
