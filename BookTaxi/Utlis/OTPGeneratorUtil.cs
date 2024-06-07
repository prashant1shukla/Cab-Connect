namespace BookTaxi.Utlis
{
    public class OTPGeneratorUtil
    {
        public static string GenerateOTP()
        {
            // Generate a random 4-digit OTP
            Random random = new Random();
            int otp = random.Next(1000, 9999);
            return otp.ToString();
        }
    }
}
