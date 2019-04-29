﻿using System;
using System.Collections.Generic;

namespace EFCoreMapStoneV13
{
    public partial class Card
    {
        public Card()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public Guid IdCardType { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdBrand { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int HasPassword { get; set; }
        public string Password { get; set; }
        public decimal Limit { get; set; }
        public decimal LimitAvailable { get; set; }
        public int Attempts { get; set; }
        public int Blocked { get; set; }

        public virtual CardBrand IdBrandNavigation { get; set; }
        public virtual CardType IdCardTypeNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}