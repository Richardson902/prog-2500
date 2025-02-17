using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using kin4.synched;

namespace kin4.notsynched
{
    internal class Data
    {
        private String favoriteCharacter = "Unknown";
        private FavoriteColor favoriteColor;

        public Data(String favoriteCharacter, FavoriteColor favoriteColor)
        {
            this.favoriteCharacter = favoriteCharacter;
            this.favoriteColor = favoriteColor;
        }

        public void setThreadPerson(String favoriteCharacter, FavoriteColor favoriteColor)
        {
            // lock during read/writes
            // lock (read_write_data)
            {
                // update the data
                this.favoriteCharacter = favoriteCharacter;
                Thread.Sleep(1);
                this.favoriteColor = favoriteColor;
            }

        }

        public String getThreadperson()
        {
            String r = "";

            // lock during read/writes
            //lock (read_write_data)
            {
                // update the data
                r = r + this.favoriteCharacter;
                //Thread.Sleep(1);
                r = r + this.favoriteColor;
                //Thread.Sleep(1);

            }

            return r;
        }
    }
}
