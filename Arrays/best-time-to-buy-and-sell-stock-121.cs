// O(n) time
// O(1) space

public int MaxProfit(int[] prices) {
	int left = 0;
	int buyPrice = prices[left];
	int maxProfit = 0;

	for(int i =0; i< prices.Length; i++){
		buyPrice = Math.Min(buyPrice, prices[i]);
		maxProfit = Math.Max(maxProfit,prices[i] - buyPrice);
	}
	return maxProfit;
}