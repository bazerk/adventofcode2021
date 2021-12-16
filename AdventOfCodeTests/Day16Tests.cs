using AdventOfCode.day16;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day16Tests {
    [Test]
    public void TestBitStreamConversion() {
        var bitstream = PacketDecoder.GetBitStream("D2FE28");
        Assert.AreEqual("110100101111111000101000", bitstream);
    }
    
    [Test]
    public void TestDecodeLiteralPacket() {
        var packet = PacketDecoder.DecodeHexString("D2FE28");
        Assert.AreEqual(2021, packet.LiteralValue);
    }
    
    [Test]
    public void TestDecodeOperatorPacketWithBitLength() {
        var packet = PacketDecoder.DecodeHexString("38006F45291200");
        Assert.AreEqual(2, packet.Children.Count);
    }
    
    [Test]
    public void TestDecodeOperatorPacketWithChildLength() {
        var packet = PacketDecoder.DecodeHexString("EE00D40C823060");
        Assert.AreEqual(3, packet.Children.Count);
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var value = Solver.SumVersions("A0016C880162017C3686B18A3D4780");
        Assert.AreEqual(31, value);
    }
    
    [Test]
    public void TestSumOperator() {
        var packet = PacketDecoder.DecodeHexString("C200B40A82");
        Assert.AreEqual(3, packet.GetValue());
    }
    
    [Test]
    public void TestProductOperator() {
        var packet = PacketDecoder.DecodeHexString("04005AC33890");
        Assert.AreEqual(54, packet.GetValue());
    }
    
    [Test]
    public void TestMinOperator() {
        var packet = PacketDecoder.DecodeHexString("880086C3E88112");
        Assert.AreEqual(7, packet.GetValue());
    }
    
    [Test]
    public void TestMaxOperator() {
        var packet = PacketDecoder.DecodeHexString("CE00C43D881120");
        Assert.AreEqual(9, packet.GetValue());
    }
    
    [Test]
    public void TestLessThanOperator() {
        var packet = PacketDecoder.DecodeHexString("D8005AC2A8F0");
        Assert.AreEqual(1, packet.GetValue());
    }
    
    [Test]
    public void TestGreaterThanOperator() {
        var packet = PacketDecoder.DecodeHexString("F600BC2D8F");
        Assert.AreEqual(0, packet.GetValue());
    }
    
    [Test]
    public void TestEqualToOperator1() {
        var packet = PacketDecoder.DecodeHexString("9C005AC2F8F0");
        Assert.AreEqual(0, packet.GetValue());
    }
    
    [Test]
    public void TestEqualToOperator2() {
        var packet = PacketDecoder.DecodeHexString("9C0141080250320F1802104A08");
        Assert.AreEqual(1, packet.GetValue());
    }
}