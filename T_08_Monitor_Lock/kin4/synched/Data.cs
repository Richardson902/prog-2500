using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Policy;

namespace kin4.synched
{
    public enum FavoriteColor
    {
        Silver, Brown, Yellow
    }

    internal class Data
    {
        // object for lock.  Note same lock for reading as with writing
        private readonly String read_write_data = "LOCK";
        private String favoriteCharacter = "Unknown";
        private FavoriteColor favoriteColor;

        public Data(String favoriteCharacter, FavoriteColor favoriteColor) {
            this.favoriteCharacter = favoriteCharacter;
            this.favoriteColor = favoriteColor;
            //Thread.Sleep(0);
        }

        public void setThreadPerson(String favoriteCharacter, FavoriteColor favoriteColor)
        {
            // lock during read/writes
            lock (read_write_data)
            {
                // update the data
                Thread.Sleep(1);
                this.favoriteCharacter = favoriteCharacter;
                Thread.Sleep(1);
                this.favoriteColor = favoriteColor;
            }

        }

        public String getThreadperson()
        {
            String r = "";

            // lock during read/writes
            lock (read_write_data)
            {
                // update the data
                r = r + this.favoriteCharacter;
                Thread.Sleep(1);
                r = r + this.favoriteColor;
            }

            return r;
        }
    }
}
