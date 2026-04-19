using AutoMapper;
using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var data = await _repo.GetAll();
            return _mapper.Map<IEnumerable<CourseDto>>(data);
        }

        public async Task<CourseDto> GetById(int id)
        {
            var data = await _repo.GetById(id);
            return _mapper.Map<CourseDto>(data);
        }

      public async Task<CourseDto> Create(CourseDto dto)
{
    var entity = _mapper.Map<Course>(dto);

    entity.CourseId = 0;

    // ✅ FIXED
    entity.CreatedBy = dto.CreatedBy;
    entity.CreatedAt = DateTime.Now;

    await _repo.Add(entity);

    return _mapper.Map<CourseDto>(entity);
}
        public async Task<bool> Update(int id, CourseDto dto)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            existing.Title = dto.Title;
            existing.Description = dto.Description;

            await _repo.Update(existing);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            await _repo.Delete(id);
            return true;
        }
    }
}