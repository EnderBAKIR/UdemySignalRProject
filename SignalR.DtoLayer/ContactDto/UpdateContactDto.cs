﻿namespace SignalR.DtoLayer.ContactDto
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string FooterDescription { get; set; }
    }
}
