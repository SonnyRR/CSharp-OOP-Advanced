namespace P07_InfernoInfinity.Engine.Entities
{
    using System;

    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name, int revision, string description, string reviewers)
        {
            Name = name;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Name { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string Reviewers { get; set; }
    }
}
