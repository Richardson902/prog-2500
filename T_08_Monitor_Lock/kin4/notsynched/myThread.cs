using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using kin4.synched;

namespace kin4.notsynched
{
    internal class myThread
    {

        notsynched.Data dorthy;

        private String favoriteCharacter;
        private FavoriteColor favoriteColor;

        public myThread(notsynched.Data dorthy, String favoriteCharacter, FavoriteColor favoriteColor)
        {
            // the object reference to update, each thread gets the same
            this.dorthy = dorthy;

            // the data that this thread will update with
            this.favoriteCharacter = favoriteCharacter;
            this.favoriteColor = favoriteColor;
        }

        public void ThreadProc()
        {
            for (int i = 0; i < 180; i++)
            {
                dorthy.setThreadPerson(this.favoriteCharacter, this.favoriteColor);
                // Yield the rest of the time slice.
                Thread.Sleep(1);
            }
        }
    }   
}
