using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
            var isFirstItem = true;
            double previousItem = 0;
            foreach (var item in data)
            {
                var point = new DataPoint();
                point.AvgSmoothedY = item.AvgSmoothedY;
                point.MaxY = item.MaxY;
                point.OriginalY = item.OriginalY;
                point.X = item.X;
                if (isFirstItem)
                {
                    isFirstItem = false;
                    previousItem = item.OriginalY;
                }
                else
                {
                    previousItem = alpha * item.OriginalY + (1 - alpha) * previousItem;
                }
                point.ExpSmoothedY = previousItem;
                yield return point;
            }
        }
	}
}