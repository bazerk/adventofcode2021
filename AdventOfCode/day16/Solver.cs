namespace AdventOfCode.day16; 

public static class Solver {

    private static int SumVersions(Packet packet) {
        var value = packet.Version;
        foreach (var child in packet.Children) {
            value += SumVersions(child);
        }

        return value;
    }
    
    public static int SumVersions(string hexString) {
        var topLevelPacket = PacketDecoder.DecodeHexString(hexString);
        return SumVersions(topLevelPacket);
    }
    
    public static int SolveStar1(string filename = "day16/input1.txt") {
        var hexString = File.ReadAllText(filename);
        return SumVersions(hexString);
    }
    
    public static long SolveStar2(string filename = "day16/input1.txt") {
        var hexString = File.ReadAllText(filename);
        var packet = PacketDecoder.DecodeHexString(hexString);
        return packet.GetValue();
    }
}