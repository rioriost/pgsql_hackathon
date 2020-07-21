for line in $(seq 1000); do
    buf="";
    for i in {0..23}; do
        for j in 00 10 20 30 40 50; do
            rnd=$RANDOM;
            tmp=$(echo "scale=2; 10 + $rnd / 32768 * 40" | bc);
            buf="$buf,$tmp";
        done;
    done;
    echo "tag-tmp$line$buf";
done > dummy.data
