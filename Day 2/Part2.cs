namespace AdventOfCode2025.Day_2;

public class Day2Part2
{
	public static void Run()
	{
		var products = GetInput();
		
		foreach (var product in products)
		{
			product.GetRepeatingSubstringInvalids();
		}
		
		long totalOfInvalids = 0;
		foreach (Products product in products)
		{
			totalOfInvalids += product.GetInvalidTotal();
		}
		
		Console.WriteLine($"Total: \n{totalOfInvalids}");
	}
	
	private static List<Products> GetInput()
	{
		List<Products> products = new List<Products>();
		var input = File.ReadAllLines($@"Inputs\input_day2.txt").FirstOrDefault().Split(',');

		
		foreach (String line in input)
		{
			Products product = new Products(line);
			products.Add(product);
		}
        
		return products;
	}   

}