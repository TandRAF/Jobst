
import { JobOffer } from '../../componets/JobOffer/jobOffer'
import "../FeedPage/_feedPage.scss"

type JobData = {
  postedAt: string;
  company: string;
  jobTitle: string;
  tags: string[];
  chance: number;
};

export const FeedPage = () => {

  const jobOffers: JobData[] = [
    {
      postedAt: "3 days ago",
      company: "Google",
      jobTitle: "React Junior Engineer",
      tags: ["React.js", "Node.js", "Web Developer"],
      chance: 65
    },
    {
      postedAt: "1 week ago",
      company: "Amazon",
      jobTitle: "Frontend Developer",
      tags: ["TypeScript", "React.js", "Angular"],
      chance: 72
    },
    {
      postedAt: "2 days ago",
      company: "Meta",
      jobTitle: "Fullstack Engineer",
      tags: ["Node.js", "GraphQL", "MongoDB"],
      chance: 59
    },
    {
      postedAt: "5 days ago",
      company: "Jobst",
      jobTitle: ".NET Engineer",
      tags: [".NET", "SMSS", "Entity Framework"],
      chance: 23
    },    
    {
      postedAt: "5 days ago",
      company: "Jobst",
      jobTitle: ".NET Engineer",
      tags: [".NET", "SMSS", "Entity Framework"],
      chance: 23
    }
  ];
  
  return (
    <div className='feed'>
        <div className="number-of-matches">
            You have matched {jobOffers.length} job offer{jobOffers.length !== 1 ? 's' : ''}.
        </div>
        <div className="feed-of-matches">
          {jobOffers.map((job, index) => (
              <JobOffer
                key={index}
                postedAt={job.postedAt}
                company={job.company}
                jobTitle={job.jobTitle}
                tags={job.tags}
                chance={job.chance}
              />
          ))}
      </div>

    </div>
  )
}
