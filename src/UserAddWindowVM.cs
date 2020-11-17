using JOYLAND.Model;
using JOYLAND.Repository;
using System.ComponentModel;

namespace JOYLAND {
    internal class UserAddWindowVM {
        private readonly PlayerDataRepository playerDataRepository = PlayerDataRepository.Instance;
        public string playerName { get; set; } = null;
        public string vf { get; set; }

        public void Save() {
            if (playerName == null || vf.Length != 5) {
                return;
            }

            int id = playerDataRepository.GenerateID();
            playerDataRepository.Save(new PlayerData(id, playerName, double.Parse(vf)));
        }
    }
}
