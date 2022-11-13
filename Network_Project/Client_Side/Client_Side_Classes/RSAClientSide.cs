using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client_Side.Client_Side_Classes
{
    public class RSAClientSide
    {
        private RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        private RSAParameters publicKey;
        private RSAParameters privateKey;
        public RSAClientSide()
        {
            privateKey = rsa.ExportParameters(true);
            publicKey = rsa.ExportParameters(false);
        }
        public string GetKeyString(bool showPubKey = true)
        {
            var sw = new StringWriter();
            var ser = new XmlSerializer(typeof(RSAParameters));
            if (showPubKey)
                ser.Serialize(sw, publicKey);
            else
                ser.Serialize(sw, privateKey);
            return sw.ToString();
        }
        public string Encrypt(string plainTexe, string publicKey)
        {
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(GetRSAParameter(publicKey));
            //rsa.ImportParameters(this.publicKey);
            var data = Encoding.Unicode.GetBytes(plainTexe);
            var cipheredText = rsa.Encrypt(data, false);
            return Convert.ToBase64String(cipheredText);
        }
        public string Encrypt(byte[] plainTexe, string publicKey)
        {
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(GetRSAParameter(publicKey));
            var cipheredText = rsa.Encrypt(plainTexe, false);
            return Convert.ToBase64String(cipheredText);
        }
        private RSAParameters GetRSAParameter(string publicKey)
        {
            string pub = publicKey;
            string mod = pub.Substring(pub.IndexOf("lus>") + 4);
            mod = mod.Substring(0, mod.IndexOf("</Modulus"));
            string exp = pub.Substring(pub.IndexOf("ent>") + 4);
            exp = exp.Substring(0, exp.IndexOf("</Exponent"));
            RSAParameters parameter = new RSAParameters();
            parameter.Modulus = Convert.FromBase64String(mod);
            parameter.Exponent = Convert.FromBase64String(exp);
            return parameter;
        }
        internal string Decrypt(string cipheredText)
        {
            var textByte = Convert.FromBase64String(cipheredText);
            rsa.ImportParameters(privateKey);
            var plainText = rsa.Decrypt(textByte, false);
            return Encoding.Unicode.GetString(plainText);
        }
        internal string Decrypt(byte [] cipheredText)
        {
            rsa.ImportParameters(privateKey);
            var plainText = rsa.Decrypt(cipheredText, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
