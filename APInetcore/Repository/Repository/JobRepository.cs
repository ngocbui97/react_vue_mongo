﻿using Repository.EF;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
    }
}
