using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;

namespace eastnetic.Server.Interfaces
{
    public interface IWindow
    {
        public List<WindowDto> GetWindowDetails();

        public void AddWindow(WindowDto Window);

        public void UpdateWindowDetails(WindowDto Window);

        public WindowDto GetWindowData(int id);

        public void DeleteWindow(int id);
    }
}