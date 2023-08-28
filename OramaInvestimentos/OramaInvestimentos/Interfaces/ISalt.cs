namespace OramaInvestimentos.Interfaces {
    public interface ISalt {

        byte[] GetSalt();
        byte[] GetHash(string value, byte[] salt);
        bool CheckHash(string password, byte[] hashedPassword, byte[] salt);
    }
}
