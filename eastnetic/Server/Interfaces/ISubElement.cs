using eastnetic.Shared.DTO;

namespace eastnetic.Server.Interfaces
{
    public interface ISubElement
    {
        public List<SubElementDto> GetSubElementDetails();

        public void AddSubElement(SubElementDto SubElement);

        public void UpdateSubElementDetails(SubElementDto SubElement);

        public SubElementDto GetSubElementData(int id);

        public void DeleteSubElement(int id);
    }
}