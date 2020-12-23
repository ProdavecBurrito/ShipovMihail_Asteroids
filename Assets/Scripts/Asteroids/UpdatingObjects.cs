using System.Collections.Generic;

namespace Shipov_Asteroids
{
    internal sealed class UpdatingObjects
    {
        private List<IUpdate> _updatingObjects;
        public int Count => _updatingObjects.Count;

        public void AddUpdateObject(IUpdate updatingObject)
        {
            if (_updatingObjects == null)
            {
                _updatingObjects = new List<IUpdate>();
            }
            _updatingObjects.Add(updatingObject);
        }

        public void RemoveUpdatingObject(IUpdate updatingObject)
        {
            _updatingObjects.Remove(updatingObject);
        }

        public IUpdate this[int index]
        {
            get => _updatingObjects[index];
            private set => _updatingObjects[index] = value;
        }
    }
}
