using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Custom_Logic
{
    [XmlInclude(typeof(WorkerAdder))]
    [XmlInclude(typeof(WorkerChanger))]
    [XmlInclude(typeof(WorkerCreater))]
    [XmlInclude(typeof(WorkerDeleter))]
    [XmlInclude(typeof(ComputerAdder))]
    [XmlInclude(typeof(ComputerChanger))]
    [XmlInclude(typeof(ComputerCreater))]
    [XmlInclude(typeof(ComputerDeleter))]
    [XmlInclude(typeof(DepartmentDeleter))]
    [XmlInclude(typeof(DepartmentCreater))]
    [XmlInclude(typeof(DepartmentChanger))]
    [XmlInclude(typeof(RecordSaver))]
    [XmlInclude(typeof(ConnectionStarter))]
    [XmlInclude(typeof(RecordGet))]

    public abstract class ICommand
    {
    }

    public interface ICommandHandler
    {
        object Execute(ICommand command);
    }
}
