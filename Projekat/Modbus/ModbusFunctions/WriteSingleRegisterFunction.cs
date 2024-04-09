using Common;
using Modbus.FunctionParameters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Modbus.ModbusFunctions
{
    /// <summary>
    /// Class containing logic for parsing and packing modbus write single register functions/requests.
    /// </summary>
    public class WriteSingleRegisterFunction : ModbusFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteSingleRegisterFunction"/> class.
        /// </summary>
        /// <param name="commandParameters">The modbus command parameters.</param>
        public WriteSingleRegisterFunction(ModbusCommandParameters commandParameters) : base(commandParameters)
        {
            CheckArguments(MethodBase.GetCurrentMethod(), typeof(ModbusWriteCommandParameters));
        }

        /// <inheritdoc />
        public override byte[] PackRequest()
        {
            //TO DO: IMPLEMENT
            byte[] request = new byte[12];

            ModbusWriteCommandParameters ModbusWrite = (ModbusWriteCommandParameters)this.CommandParameters;

            request[0] = BitConverter.GetBytes(CommandParameters.TransactionId)[1];
            request[1] = BitConverter.GetBytes(CommandParameters.TransactionId)[0];
            request[2] = BitConverter.GetBytes(CommandParameters.ProtocolId)[1];
            request[3] = BitConverter.GetBytes(CommandParameters.ProtocolId)[0];
            request[4] = BitConverter.GetBytes(CommandParameters.Length)[1];
            request[5] = BitConverter.GetBytes(CommandParameters.Length)[0];
            request[6] = CommandParameters.UnitId;
            request[7] = CommandParameters.FunctionCode;
            request[8] = BitConverter.GetBytes(ModbusWrite.OutputAddress)[1];
            request[9] = BitConverter.GetBytes(ModbusWrite.OutputAddress)[0];
            request[10] = BitConverter.GetBytes(ModbusWrite.Value)[1];
            request[11] = BitConverter.GetBytes(ModbusWrite.Value)[0];

            return request;

        }

        /// <inheritdoc />
        public override Dictionary<Tuple<PointType, ushort>, ushort> ParseResponse(byte[] response)
        {
            //TO DO: IMPLEMENT
            Dictionary<Tuple<PointType, ushort>, ushort> dict = new Dictionary<Tuple<PointType, ushort>, ushort>();

            ushort address = (ushort)IPAddress.NetworkToHostOrder((short)BitConverter.ToUInt16(response, 8));
            ushort value = (ushort)IPAddress.NetworkToHostOrder((short)BitConverter.ToUInt16(response, 10));

            Tuple<PointType, ushort> tuple = new Tuple<PointType, ushort>(PointType.ANALOG_OUTPUT, address);
            dict.Add(tuple, value);

            return dict;
        }
    }
}