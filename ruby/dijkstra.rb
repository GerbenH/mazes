require 'distance_grid'
require 'binary_tree'
require 'sidewinder'

grid = DistanceGrid.new(5,5)
Sidewinder.on(grid)

start = grid[0,0]
distances = start.distances

grid.distances = distances
puts grid.to_s

puts "path from northwest to southwest corner"
grid.distances = distances.path_to(grid[grid.rows-1,grid.columns-1])
puts grid.to_s