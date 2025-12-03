namespace AdventOfCode2025.Day_2;

public class Products
{
	public long RangeStart;
	public long RangeEnd;
	public List<long> Invalids = new();

	public Products(string range)
	{
		var rangeList = range.Split('-');
		RangeStart = long.Parse(rangeList[0]);
		RangeEnd = long.Parse(rangeList[1]);
	}

	public void GetRepdigitInvalids()
	{
		for (long i = RangeStart; i <= RangeEnd; i++)
		{
			int halfwayIndex = i.ToString().Length / 2;
			var firstHalf = i.ToString().Substring(0, halfwayIndex);
			var secondHalf = i.ToString().Substring(halfwayIndex);

			if (firstHalf == secondHalf) Invalids.Add(i);
		}
	}

	public void GetRepeatingSubstringInvalids()
	{
		for (long value = RangeStart; value <= RangeEnd; value++)
		{
			ValidateValueForSubstringInvalidation(value);
		}
	}

	private void ValidateValueForSubstringInvalidation(long value)
	{
		for (int y = 0; y <= value.ToString().Length; y++)
		{
			string substring = value.ToString().Substring(0, y);
			if (substring.Length == 0) continue;

			string butcheredString = value.ToString().Substring(y);
			while (substring.Length <= butcheredString.Length)
			{
				if (substring == butcheredString.Substring(0, substring.Length))
				{
					butcheredString = butcheredString.Remove(0, substring.Length);
				}
				else
				{
					butcheredString = "";
					continue;
				}

				if (butcheredString.Length == 0)
				{
					Invalids.Add(value);
					return;
				}
			}
		}
	}

	public long GetInvalidTotal()
	{
		long total = 0;
		foreach (long invalid in Invalids)
		{
			total += invalid;
		}

		return total;
	}
}