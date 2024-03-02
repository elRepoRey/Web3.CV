using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;


namespace Delgado.Shared
{
    public class CV : IBsonId
    {        
        public Guid Id { get; set; }
        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; }
        [BsonElement("PhoneNumber")]
        public string? PhoneNumber { get; set; }        
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
        public string? Summary { get; set; }
        public string[]? Skills { get; set; } = new string[0];
        public Experience[]? Experiences { get; set; } = new Experience[0];
        public Degree[]? Degrees { get; set; } = new Degree[0];
        public Project[]? Projects { get; set; } = new Project[0];

        public CV()
        {
            Id = Guid.NewGuid();
        }

        public void AddExperience(Experience experience)
        {
            var list = Experiences.ToList();
            list.Add(experience);
            Experiences = list.ToArray();
        }

        public void AddDegree(Degree degree)
        {
            var list = Degrees.ToList();
            list.Add(degree);
            Degrees = list.ToArray();
        }

        public void AddProject(Project project)
        {
            var list = Projects.ToList();
            list.Add(project);
            Projects = list.ToArray();
        }

        public void AddSkill(string skill)
        {
            var list = Skills.ToList();
            list.Add(skill);
            Skills = list.ToArray();
        }

    }

    public class Experience
    {                
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class Degree
    {              
        public string Title { get; set; }
        public string School { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
    }



    public class Project
    {             

        public string Name { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public string Features { get; set; }
    }
      
}
