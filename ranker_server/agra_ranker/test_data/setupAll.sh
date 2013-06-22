#!/bin/bash
for f in *_setup.js
do
    echo "running $f"
    ./$1 $2 $f
done
