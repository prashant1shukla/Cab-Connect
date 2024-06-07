namespace BookTaxi.Utlis
{
    public class OTPGeneratorUtil
    {
        // Generate a random 4-digit OTP
        public static string GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(1000, 9999);
            return otp.ToString();
        }
    }
}
