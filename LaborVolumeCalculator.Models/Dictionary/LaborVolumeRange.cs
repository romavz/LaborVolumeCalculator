namespace LaborVolumeCalculator.Models.Dictionary
{
    public class LaborVolumeRange
    {
        public LaborVolumeRange()
        {
        }

        public LaborVolumeRange(double minVolume, double maxVolume)
        {
            MinVolume = minVolume;
            MaxVolume = maxVolume;
        }

        public int ID { get; set; }
        public int LaborID { get; set; }
        
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }

    }
}