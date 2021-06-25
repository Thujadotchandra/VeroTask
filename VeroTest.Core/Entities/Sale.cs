using System;
using System.Collections.Generic;

namespace VeroTest.Core.Entities
{
    public class Sale : Entity
    {

        public string EmailAddress { get; private set; }


        public void Buy(string emailAddress, Song song)
        {
            EmailAddress = emailAddress;
            Song= song;
        }

        public Song Song  { get; private set; }
    }
}
