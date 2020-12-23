namespace Shipov_Asteroids
{
    internal sealed class ObjectsInitializator
    {
        private UpdatingObjects _updatingObjects;
        private InputController _inputController;
        private Movement playerMovement;

        public UpdatingObjects UpdatingObjects { get => _updatingObjects; private set => _updatingObjects = value; }
        public InputController InputController { get => _inputController; private set => _inputController = value; }
        public Movement PlayerMovement { get => playerMovement; private set => playerMovement = value; }

        public ObjectsInitializator()
        {

        }
    }
}
